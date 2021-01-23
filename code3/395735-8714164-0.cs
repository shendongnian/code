    foreach (var image in images)
    {
        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
    
        if (pic.Height > pic.Width)
        {
            //Maximum height is 800 pixels.
            float percentage = 0.0f;
            percentage = 700 / pic.Height;
            pic.ScalePercent(percentage * 100);
        }
        else
        {
            //Maximum width is 600 pixels.
            float percentage = 0.0f;
            percentage = 540 / pic.Width;
            pic.ScalePercent(percentage * 100);
        }
    
        pic.Border = iTextSharp.text.Rectangle.BOX;
        pic.BorderColor = iTextSharp.text.BaseColor.BLACK;
        pic.BorderWidth = 3f;
        document.Add(pic);
        document.NewPage();
    }
