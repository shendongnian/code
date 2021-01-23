    public void SaveImage(string base64)
    {
        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64)))
        {
            using (Bitmap bm2 = new Bitmap(ms))
            {
                bm2.Save("SavingPath" + "ImageName.jpg");
            }
        }
    }
