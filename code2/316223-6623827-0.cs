    void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) {
            String tipText = String.Format("({0}, {1})", e.X, e.Y);
            trackTip.Show(tipText, this, e.Location);
        }
    }
