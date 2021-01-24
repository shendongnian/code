    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        string pathImage = Environment.CurrentDirectory + "\\chart1.png";
        chart1.SaveImage(pathImage, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
        using (var newImage = Image.FromFile(pathImage))
        {
            Point ulCorner = new Point(50, 425);
            e.Graphics.DrawImage(newImage, ulCorner);
        }
    }
