    protected override void OnPaint(PaintEventArgs eventArgs)
    {
        using (Font myFont = new System.Drawing.Font("Helvetica", 40,  FontStyle.Italic))
            {
            eventArgs.Graphics.TranslateTransform(0, 0);
            Point p = this.PointToScreen(new Point(200, 200));
            eventArgs.Graphics.DrawString("Hello C#", myFont, System.Drawing.Brushes.Red, p);
            } //myFont is automatically disposed here, even if an exception was thrown            
    }
