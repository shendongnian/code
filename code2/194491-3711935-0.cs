    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        foreach (var str in data)
        {
            e.Graphics.TranslateTransform(str.X, str.Y);
            e.Graphics.RotateTransform(30);
            e.Graphics.DrawString(str.StringName, mFont, new SolidBrush(Color.Black), new Point(0, 0));
            e.Graphics.ResetTransform();
        }
    }
