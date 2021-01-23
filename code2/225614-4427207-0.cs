        using (Bitmap bitmap = (Bitmap)Image.FromFile("file.jpg"))
        {
            using (Bitmap newBitmap = new Bitmap(bitmap))
            {
                newBitmap.SetResolution(300, 300);
                newBitmap.Save("file300.jpg", ImageFormat.Jpeg);
            }
        }
