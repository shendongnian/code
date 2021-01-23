    public Bitmap Bitmap
    {
        get
        {
            using (var graphics = this.CreateGraphics())
            {
                return new Bitmap(100, 100, graphics);
            }
        }
    }
