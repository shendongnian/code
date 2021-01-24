    // A 2x2 image having ARGB pixel format, all pixels are #FF0000 (Red)
    var imageData = new ImageData()
    {
        Width = 2,
        Height = 2,
        PixelFormat = PixelFormat.Format32bppArgb,
        PixelData = new byte[] {
            0x0, 0x0, 0xFF, 0xFF, 0x0, 0x0, 0xFF, 0xFF,
            0xF, 0x0, 0xFF, 0xFF, 0x0, 0x0, 0xFF, 0xFF
        }
    };
    var image = CreateImageFromImageData(imageData);
    var jpeg = ConvertImageToJpegImage(image);
    var jpegImageData = GetImageDataFromImage(jpeg);
    var jpegPixelsBase64 = ByteArrayToBase64(jpegImageData.PixelData);
