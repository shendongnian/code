    class EPPTest
    {
    public void CreateExcel(string filename)
    {
        var fi = new FileInfo(filename);
        
        using (var excel = new ExcelPackage(fi) )
        using (var img = CreateImage() )
        {
            if( excel.Workbook.Worksheets.Count == 0 )
            {
                excel.Workbook.Worksheets.Add("MySheet");
            }
            foreach (var sheet in excel.Workbook.Worksheets)
            {
                sheet.BackgroundImage.Image = img;
                sheet.Protection.IsProtected = false;
            }
            excel.Save();// As(new FileInfo(Path.GetFileNameWithoutExtension(file) + ".xlsx"));
        }
    }
    public Image CreateImage()
    {
        Bitmap img = new Bitmap(400, 400);
        
        using (Graphics g = Graphics.FromImage(img))
        using ( Font f = new Font("Tahoma", 80))
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            SizeF textSize = g.MeasureString("Sample", f);
            g.DrawString("Sample", f, Brushes.Red, 0, (textSize.Height ));
        }
        return img;
    }
