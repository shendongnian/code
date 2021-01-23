    public void SaveFormToFile(string fileName)
    {
        System.Drawing.Bitmap b = new Bitmap(this.Bounds.Width, this.Bounds.Height);
        this.DrawToBitmap(b, this.Bounds);
        b.Save(fileName );
    }
