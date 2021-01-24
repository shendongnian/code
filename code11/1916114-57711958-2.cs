    private static void PdfToPngWithGhostscriptPngDevice(string srcFile, int pageNo, int dpiX, int dpiY, string tgtFile)
    {
    	GhostscriptPngDevice dev = new GhostscriptPngDevice(GhostscriptPngDeviceType.PngGray);
    	dev.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
    	dev.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
    	dev.ResolutionXY = new GhostscriptImageDeviceResolution(dpiX, dpiY);
    	dev.InputFiles.Add(srcFile);
    	dev.Pdf.FirstPage = pageNo;
    	dev.Pdf.LastPage = pageNo;
    	dev.CustomSwitches.Add("-dDOINTERPOLATE");
    	dev.OutputPath = tgtFile;
    	dev.Process();
    }
