    public static byte[] FromExcel(string xlsFile)
    {
        XlsToPdf xtop = new SautinSoft.XlsToPdf();
        byte[] xlsBytes = File.ReadAllBytes(xlsFile);
        // is xlsBytes null? put a break-point here, or debug-print statement if you can't debug a running server.
        byte[] pdfBytes = null; 
        xtop.ConvertBytes(xlsBytes, ref pdfBytes);
        string tempFileName = string.Format("{0}{1}", Config.TempDirectory, Guid.NewGuid().ToString());
        var bw = new BinaryWriter(new FileStream(tempFileName, FileMode.CreateNew));
        bw.Write(pdfBytes);
        bw.Close();
        return pdfBytes;
    }
