    private void PictureEditorOnMouseMove(Object sender, MouseEventArgs e)
    {   
        if(e.Button == MouseButtons.Left)
        {
            PictureEdit pce = sender as PictureEdit;
            Bitmap bmpImage = pce.Image as Bitmap;
            PictureEditViewInfo viewInfo = pce.GetViewInfo() as PictureEditViewInfo;
            var p = new Point(
                (e.Location.X - viewInfo.PictureStartX) * bmpImage.Width / viewInfo.PictureRect.Width,
                (e.Location.Y - viewInfo.PictureStartY) * bmpImage.Height / viewInfo.PictureRect.Height);
            if (p.X >= 0 && p.X < bmpImage.Width && p.Y >= 0 && p.Y < bmpImage.Height)
            {
                bmpImage.SetPixel(p.X, p.Y, this.colorPicker.Color);
            }
            else
            {
                Console.WriteLine("Out bounds");
            }
        }
    }
