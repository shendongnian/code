        byte[] fontData = Properties.Resources.FONT_RESOURCE_NAME_HERE;
        IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
        System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
        uint dummy = 0;
        fonts.AddMemoryFont(fontPtr, fontData.Length);
        AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
        Font memoryLoadedFont = new Font(fonts.Families[0], 16.0F);
