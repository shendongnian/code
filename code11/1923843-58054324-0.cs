    var original = @"D:\tmp\0.tif";
    var copy = @"D:\tmp\0.bmp";
    using (var image = new MagickImage(original))
    {
        image.Grayscale();
        image.ColorType = ColorType.Palette;
        image.Quantize(new QuantizeSettings() { Colors = 256, DitherMethod = DitherMethod.No });
        byte[] result = image.ToByteArray(MagickFormat.Png8);
        File.WriteAllBytes(copy, result);
    }
    Console.WriteLine("Press 'Enter'..."); // one have 8 bits .png here
    Console.ReadLine();
    using (var image = new MagickImage(copy))
    {
        byte[] result = image.ToByteArray(MagickFormat.Bmp3);
        File.WriteAllBytes(copy, result);
    } // but ends up with 32 bits .bmp again here
