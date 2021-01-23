    protected override void OnPaint(PaintEventArgs e)
    {
        var tempRocket = new Bitmap(Properties.Resources.rocket);
        using (var g = Graphics.FromImage(tempRocket))
        {
            e.Graphics.DrawImage(tempRocket, 150, 150);
            e.Graphics.RotateTransform(30.0F);
        }
    }
