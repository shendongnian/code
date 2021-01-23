    public string SelectedRtf
        {
          get
          {
            this.ForceHandleCreate();
            return this.StreamOut(32770);
          }
          set
          {
            this.ForceHandleCreate();
            if (value == null)
              value = "";
            this.StreamIn(value, 32770);
          }
        }
    private void StreamIn(string str, int flags)
    {
      if (str.Length == 0)
      {
        if ((32768 & flags) != 0)
        {
          this.SendMessage(771, 0, 0);
          this.ProtectedError = false;
        }
        else
          this.SendMessage(12, 0, "");
      }
      else
      {
        int length = str.IndexOf(char.MinValue);
        if (length != -1)
          str = str.Substring(0, length);
        byte[] buffer = (flags & 16) == 0 ? Encoding.Default.GetBytes(str) : Encoding.Unicode.GetBytes(str);
        this.editStream = (Stream) new MemoryStream(buffer.Length);
        this.editStream.Write(buffer, 0, buffer.Length);
        this.editStream.Position = 0L;
        this.StreamIn(this.editStream, flags);
      }
    }
    private void StreamIn(Stream data, int flags)
    {
      if ((flags & 32768) == 0)
        System.Windows.Forms.UnsafeNativeMethods.SendMessage(new HandleRef((object) this, this.Handle), 1079, 0, new System.Windows.Forms.NativeMethods.CHARRANGE());
      try
      {
        this.editStream = data;
        if ((flags & 2) != 0)
        {
          long position = this.editStream.Position;
          byte[] numArray = new byte[RichTextBox.SZ_RTF_TAG.Length];
          this.editStream.Read(numArray, (int) position, RichTextBox.SZ_RTF_TAG.Length);
          string @string = Encoding.Default.GetString(numArray);
          if (!RichTextBox.SZ_RTF_TAG.Equals(@string))
            throw new ArgumentException(System.Windows.Forms.SR.GetString("InvalidFileFormat"));
          this.editStream.Position = position;
        }
        System.Windows.Forms.NativeMethods.EDITSTREAM editstream = new System.Windows.Forms.NativeMethods.EDITSTREAM();
        int num1 = (flags & 16) == 0 ? 5 : 9;
        int num2 = (flags & 2) == 0 ? num1 | 16 : num1 | 64;
        editstream.dwCookie = (IntPtr) num2;
        editstream.pfnCallback = new System.Windows.Forms.NativeMethods.EditStreamCallback(this.EditStreamProc);
        this.SendMessage(1077, 0, int.MaxValue);
        if (IntPtr.Size == 8)
        {
          System.Windows.Forms.NativeMethods.EDITSTREAM64 editstreaM64 = this.ConvertToEDITSTREAM64(editstream);
          System.Windows.Forms.UnsafeNativeMethods.SendMessage(new HandleRef((object) this, this.Handle), 1097, flags, editstreaM64);
          editstream.dwError = this.GetErrorValue64(editstreaM64);
        }
        else
          System.Windows.Forms.UnsafeNativeMethods.SendMessage(new HandleRef((object) this, this.Handle), 1097, flags, editstream);
        this.UpdateMaxLength();
        if (this.GetProtectedError())
          return;
        if (editstream.dwError != 0)
          throw new InvalidOperationException(System.Windows.Forms.SR.GetString("LoadTextError"));
        this.SendMessage(185, -1, 0);
        this.SendMessage(186, 0, 0);
      }
      finally
      {
        this.editStream = (Stream) null;
      }
    }
