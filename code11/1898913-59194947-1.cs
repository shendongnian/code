    if (uploadedImage.PropertyIdList.Contains(0x0112))
    {
        PropertyItem propOrientation = uploadedImage.GetPropertyItem(0x0112);
        short orientation = BitConverter.ToInt16(propOrientation.Value, 0);
        if (orientation == 6)
        {
            uploadedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
        else if (orientation == 8)
        {
            uploadedImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }
        else
        {
            // Do nothing
        }
    }
