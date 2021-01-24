    // EXIF data: orientation address.
    public const int ImageOrientationId = 0x0112;
    
    // here we use an enum for readability purposes
    public enum ExifOrientations
    {
        Unknown = 0,
        TopLeft = 1,
        TopRight = 2,
        BottomRight = 3,
        BottomLeft = 4,
        LeftTop = 5,
        RightTop = 6,
        RightBottom = 7,
        LeftBottom = 8
    }
    public static ExifOrientations ImageExifOrientation(Image img)
    {
        // check if there's a value for ImageOrientationId address
        int orientation_index =
        Array.IndexOf(img.PropertyIdList, ImageOrientationId);
        // that means there's no orientation value
        if (orientation_index < 0) return ExifOrientations.Unknown;
        // otherwise, we cast it in our enum and return it
        return (ExifOrientations)
        img.GetPropertyItem(ImageOrientationId).Value[0];
    }
