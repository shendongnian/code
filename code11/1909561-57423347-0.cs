    MagickImage pdfPage = MyCodeToGetPage();
    String barcodePng = "tmp.png"
    MagickGeometry barcodeArea = new MagickGeometry(350, 153, 208, 36);
    IMagickImage barcodeImg = pdfPage.Clone();
    barcodeImg.ColorType = ColorType.Bilevel;
    barcodeImg.Depth = 1;
    barcodeImg.Alpha(AlphaOption.Off);
    barcodeImg.Crop(barcodeArea);
    barcodeImg.Write(barcodePng);
