    public static bool SendUtf8StringToPrinter(string szPrinterName, string szString)
    {   
        // by default System.String is UTF-16 / Unicode
    	byte[] bytes = Encoding.Unicode.GetBytes(szString);
        
        // convert this to UTF-8. This is a lossy conversion and you might lose some chars
    	bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, bytes);
    	int bCount = bytes.Length;
    
        // allocate some unmanaged memory
    	IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(bCount);
        // copy the byte[] into the memory pointer
    	System.Runtime.InteropServices.Marshal.Copy(bytes, 0, ptr, bCount);
    
    	// Send the converted byte[] to the printer.
    	SendBytesToPrinter(szPrinterName, ptr, bCount);
        // free the unmanaged memory
    	System.Runtime.InteropServices.Marshal.FreeCoTaskMem(ptr);
        // it worked! Happy cry.
    	return true;
    }
