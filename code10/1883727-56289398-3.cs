    ExifOrientations exifOrientation = ImageExifOrientation(image);
    switch (exifOrientation)
    {
        case ExifOrientations.TopLeft:
            // DO NOT OPERATE ON IT
        break;
        case ExifOrientations.TopRight:
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        break;
        case ExifOrientations.BottomRight:
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
        break;
        case ExifOrientations.BottomLeft:
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        break;
        case ExifOrientations.LeftTop:
            image.RotateFlip(RotateFlipType.Rotate90FlipY);
        break;
        case ExifOrientations.RightTop:
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        break;
        case ExifOrientations.RightBottom:
            image.RotateFlip(RotateFlipType.Rotate90FlipX);
        break;
        case ExifOrientations.LeftBottom:
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        break;
    }
