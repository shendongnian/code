    using (Bitmap bitmap = new Bitmap(ParentForm.Size.Width, ParentForm.Size.Height))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
        {
          g.CopyFromScreen(new Point(ParentForm.DesktopLocation.X, ParentForm.DesktopLocation.Y), new Point(0, 0), ParentForm.Size);
        }
        bitmap.Save(@"C:\test.jpg", ImageFormat.Jpeg);
    }
