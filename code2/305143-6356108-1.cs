    public static Image Convert(Bitmap oldbmp) {
        using (var ms = new MemoryStream()) {
            oldbmp.Save(ms, ImageFormat.Gif);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
    }
