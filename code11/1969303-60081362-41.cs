    // A 2x2 image having 24 bit RGB pixel format, all pixels are #FF0000 (Red)
    var imageData = new ImageData()
    {
        Width = 2,
        Height = 2,
        PixelFormat = PixelFormat.Format24bppRgb,
        PixelData = new byte[] {
            0x0, 0x0, 0xFF,   0x0, 0x0, 0xFF,
            0xF, 0x0, 0xFF,   0x0, 0x0, 0xFF
        }
    };
    var image = CreateImageFromImageData(imageData);
    var jpeg = ConvertImageToJpegImage(image);
    var jpegImageData = GetImageDataFromImage(jpeg);
    var jpegPixelsBase64 = ByteArrayToBase64(jpegImageData.PixelData);
