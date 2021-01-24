     private void StreamIn(string str, int flags)
        {
            if (str.Length == 0)
            {
                // Destroy the selection if callers was setting
                // selection text
                //
                if ((RichTextBoxConstants.SFF_SELECTION & flags) != 0)
                {
                    SendMessage(Interop.WindowMessages.WM_CLEAR, 0, 0);
                    ProtectedError = false;
                    return;
                }
                // WM_SETTEXT is allowed even if we have protected text
                //
                SendMessage(Interop.WindowMessages.WM_SETTEXT, 0, "");
                return;
            }
            // Rather than work only some of the time with null characters,
            // we're going to be consistent and never work with them.
            int nullTerminatedLength = str.IndexOf((char)0);
            if (nullTerminatedLength != -1)
            {
                str = str.Substring(0, nullTerminatedLength);
            }
            // get the string into a byte array
            byte[] encodedBytes;
            if ((flags & RichTextBoxConstants.SF_UNICODE) != 0)
            {
                encodedBytes = Encoding.Unicode.GetBytes(str);
            }
            else
            {
                encodedBytes = Encoding.Default.GetBytes(str);
            }
            editStream = new MemoryStream(encodedBytes.Length);
            editStream.Write(encodedBytes, 0, encodedBytes.Length);
            editStream.Position = 0;
            StreamIn(editStream, flags);
        }
        private void StreamIn(Stream data, int flags)
        {
            // clear out the selection only if we are replacing all the text
            //
            if ((flags & RichTextBoxConstants.SFF_SELECTION) == 0)
            {
                NativeMethods.CHARRANGE cr = new NativeMethods.CHARRANGE();
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), Interop.EditMessages.EM_EXSETSEL, 0, cr);
            }
            try
            {
                editStream = data;
                Debug.Assert(data != null, "StreamIn passed a null stream");
                // If SF_RTF is requested then check for the RTF tag at the start
                // of the file.  We don't load if the tag is not there
                // 
                if ((flags & RichTextBoxConstants.SF_RTF) != 0)
                {
                    long streamStart = editStream.Position;
                    byte[] bytes = new byte[SZ_RTF_TAG.Length];
                    editStream.Read(bytes, (int)streamStart, SZ_RTF_TAG.Length);
                    string str = Encoding.Default.GetString(bytes);
                    if (!SZ_RTF_TAG.Equals(str))
                    {
                        throw new ArgumentException(SR.InvalidFileFormat);
                    }
                    // put us back at the start of the file
                    editStream.Position = streamStart;
                }
                int cookieVal = 0;
                // set up structure to do stream operation
                NativeMethods.EDITSTREAM es = new NativeMethods.EDITSTREAM();
                if ((flags & RichTextBoxConstants.SF_UNICODE) != 0)
                {
                    cookieVal = INPUT | UNICODE;
                }
                else
                {
                    cookieVal = INPUT | ANSI;
                }
                if ((flags & RichTextBoxConstants.SF_RTF) != 0)
                {
                    cookieVal |= RTF;
                }
                else
                {
                    cookieVal |= TEXTLF;
                }
                es.dwCookie = (IntPtr)cookieVal;
                es.pfnCallback = new NativeMethods.EditStreamCallback(EditStreamProc);
                // gives us TextBox compatible behavior, programatic text change shouldn't
                // be limited...
                //
                SendMessage(Interop.EditMessages.EM_EXLIMITTEXT, 0, int.MaxValue);
                // go get the text for the control
                // Needed for 64-bit
                if (IntPtr.Size == 8)
                {
                    NativeMethods.EDITSTREAM64 es64 = ConvertToEDITSTREAM64(es);
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), Interop.EditMessages.EM_STREAMIN, flags, es64);
                    //Assign back dwError value
                    es.dwError = GetErrorValue64(es64);
                }
                else
                {
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), Interop.EditMessages.EM_STREAMIN, flags, es);
                }
                UpdateMaxLength();
                // If we failed to load because of protected
                // text then return protect event was fired so no
                // exception is required for the the error
                if (GetProtectedError())
                {
                    return;
                }
                if (es.dwError != 0)
                {
                    throw new InvalidOperationException(SR.LoadTextError);
                }
                // set the modify tag on the control
                SendMessage(Interop.EditMessages.EM_SETMODIFY, -1, 0);
                // EM_GETLINECOUNT will cause the RichTextBoxConstants to recalculate its line indexes
                SendMessage(Interop.EditMessages.EM_GETLINECOUNT, 0, 0);
            }
            finally
            {
                // release any storage space held.
                editStream = null;
            }
        }
