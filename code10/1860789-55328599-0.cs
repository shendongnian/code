    const int margin = 2;
    MagickGeometry geometry = null;
    using (var collection = new MagickImageCollection())
    {
        for (var i = 0; i < thumbnailCount; i++)
        {
            var image = new MagickImage(TempThumbPathFor(i));
            image.Resize(256, 0);
            collection.Add(image);
            if (i == 0)
            {
                geometry = image.BoundingBox;
                geometry.X += margin;
                geometry.Width += margin;
                geometry.Y += margin;
                geometry.Height += margin - 1;
            }
        }
        using (var result = collection.Montage(new MontageSettings()
        {
            Geometry = geometry,
            BackgroundColor = MagickColor.FromRgb(255, 255, 255)
        }))
        {
            result.Trim();
            result.Write(newPath);
        }
    }
