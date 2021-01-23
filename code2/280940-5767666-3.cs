DoDragDrop(GetDataObject(new String[] { file name }), DragDropEffects.Copy);
 
    DataObject2 GetDataObject(String[] strFiles)
    {
        byte[] bData;
        _DROPFILES df = new _DROPFILES();
        int intChar, intFile, intDataLen, intPos;
        IntPtr ipGlobal = IntPtr.Zero;
        // Calculate total data length
        intDataLen = 0;
        for (intFile = 0; intFile <= strFiles.GetUpperBound(0);intFile++)
        {
            intDataLen += strFiles[intFile].Length + 1;
        }
        // Terminating double zero
        intDataLen++;
        bData = new Byte[intDataLen];
        intPos = 0;
        // Build null terminated list of files
        for (intFile = 0; intFile <= strFiles.GetUpperBound(0); intFile++)
        {
            for (intChar = 0; intChar < strFiles[intFile].Length;intChar++)
            {
                bData[intPos++] = (byte)strFiles[intFile][intChar];
            }
            bData[intPos++] = 0;
        }
        // Terminating double zero
        bData[intPos++] = 0;
        // Allocate and get pointer to global memory
        int intTotalLen = Marshal.SizeOf(df) + intDataLen;
        ipGlobal = Marshal.AllocHGlobal(intTotalLen);
        if (ipGlobal == IntPtr.Zero)
        {
            return null;
        }
        // Build DROPFILES structure in global memory.
        df.pFiles = Marshal.SizeOf(df);
        df.fWide = false;
        Marshal.StructureToPtr(df, ipGlobal, true);
        IntPtr ipNew = new IntPtr(ipGlobal.ToInt32() + Marshal.SizeOf(df));
        Marshal.Copy(bData, 0, ipNew, intDataLen);
        short CF_HDROP = 15;
        System.Runtime.InteropServices.ComTypes.FORMATETC formatEtc;
        System.Runtime.InteropServices.ComTypes.STGMEDIUM stgMedium;
        formatEtc = new System.Runtime.InteropServices.ComTypes.FORMATETC();
        formatEtc.cfFormat = CF_HDROP;
        formatEtc.dwAspect = System.Runtime.InteropServices.ComTypes.DVASPECT.DVASPECT_CONTENT;
        formatEtc.lindex = -1;
        formatEtc.tymed = System.Runtime.InteropServices.ComTypes.TYMED.TYMED_HGLOBAL;
        stgMedium = new System.Runtime.InteropServices.ComTypes.STGMEDIUM();
        stgMedium.unionmember = ipGlobal;
        stgMedium.tymed = System.Runtime.InteropServices.ComTypes.TYMED.TYMED_HGLOBAL;
        DataObject2 dobj = new DataObject2();
        dobj.SetData(ref formatEtc, ref stgMedium, false);
        return dobj;
    }
