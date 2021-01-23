    const int emusPerInch = 914400;
    const int emusPerCm = 360000;
    long widthEmus;
    long heightEmus;
    Image<Rgba32> img = Image.Load(sourceStream, new PngDecoder());
    switch (img.MetaData.ResolutionUnits)
    {
        case PixelResolutionUnit.PixelsPerCentimeter :
            widthEmus = (long)(img.Width / img.MetaData.HorizontalResolution * emusPerCm);
            heightEmus = (long)(img.Height / img.MetaData.VerticalResolution * emusPerCm);
            break;
        case PixelResolutionUnit.PixelsPerInch:
            widthEmus = (long)(img.Width / img.MetaData.HorizontalResolution * emusPerInch);
            heightEmus = (long)(img.Height / img.MetaData.VerticalResolution * emusPerInch);
            break;
        case PixelResolutionUnit.PixelsPerMeter:
            widthEmus = (long)(img.Width / img.MetaData.HorizontalResolution * emusPerCm * 100);
            heightEmus = (long)(img.Height / img.MetaData.VerticalResolution * emusPerCm * 100);
            break;
        default:
            widthEmus = 2000000;
            heightEmus = 2000000;
            break;
    }
