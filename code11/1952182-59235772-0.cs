    using (MagickImage mi = images.AppendHorizontally())
    {
        mi.Format = Image.Jpeg;
        mi.Resize(40, 40);
        mi.Quality = 10;
        mi.Write(imageFile);
    }
 
