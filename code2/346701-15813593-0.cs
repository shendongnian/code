    private void PlacePicture(Image picture, Range destination)
    {
        Worksheet ws = destination.Worksheet;
        Clipboard.SetImage(picture);
        ws.Paste(destination, false);
        Pictures p = ws.Pictures(System.Reflection.Missing.Value) as Pictures;
        Picture pic = p.Item(p.Count) as Picture;
        ScalePicture(pic, (double)destination.Width, (double)destination.Height);
    }
    private void ScalePicture(Picture pic, double width, double height)
    {
        double fX = width / pic.Width;
        double fY = height / pic.Height;
        if (fX < fY)
        {
            pic.Width *= fX;
            pic.Height *= fX;
            pic.Top += (height - pic.Height) / 2;
        }
        else
        {
            pic.Width *= fY;
            pic.Height *= fY;
            pic.Left += (width - pic.Width) / 2;
        }
    }
