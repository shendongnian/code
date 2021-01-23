    private void button2_Click(object sender, EventArgs e)
    {
        panel1.AutoSize = true;
        panel1.Refresh();
        using (Bitmap bmp = new Bitmap(panel1.Width, panel1.Height))
        {
                
           panel1.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
           string fileName = "Full_Domain_Report_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".png";       
           bmp.Save(@"C:\temp\" + fileName, ImageFormat.Png); // make sure path exists!
        }
        panel1.AutoSize = false;
        panel1.Refresh();
    }
