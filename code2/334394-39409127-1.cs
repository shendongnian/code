    public void SavePicture()
    {
    	 Bitmap bm = new Bitmap(this.myBitmap)
    	 bm.Save("Output\\out.bmp" ,System.Drawing.Imaging.ImageFormat.Bmp );
    }
