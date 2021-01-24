    private void chart1_Paint(object sender, PaintEventArgs e)
    {
        if (chart1.Series[seriesName].Points.Count == 0)
        {
            using (Font font = new Font("Consolas", 20f))
            using (StringFormat fmt = new StringFormat()
            { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString("No data yet", 
                                      font, Brushes.Black, chart1.ClientRectangle, fmt);
   
        }
    }
