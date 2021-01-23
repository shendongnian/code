    // This is for the print preview event
     private void printPreviewDialog1_Load(object sender, EventArgs e)
     {
         int j = 0;
         z = 185;
         while (j < dataGridView1.Rows.Count)
         {                 
             j += 1;
             z += 30;
         }
         z += 60;
    
         PaperSize pkCustomSize1 = new PaperSize("First custom size", 350, z);
    
         printDocument1.DefaultPageSettings.PaperSize = pkCustomSize1;
     }
     // This is the loop for generating print Document
     private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
     {
         int i = 0; //For Gridview Row Count
         int sno = 1; //For Grid Serial Number
         e.Graphics.DrawString(
             "HEADING", 
             new Font("Calibri", 20, FontStyle.Bold), 
             Brushes.Black, 
             new Point(100, 5));
         e.Graphics.DrawString(
             "Address", 
             new Font("Calibri", 12, FontStyle.Bold), 
             Brushes.Black, 
             new Point(75, 35));
        
        int y = 185; //For Grid y axis start to print 
        while (i < dataGridView1.Rows.Count)
        {
            e.Graphics.DrawString(
                sno.ToString(), 
                new Font("Calibri", 10, FontStyle.Bold), 
                Brushes.Black, 
                new Point(10, y)); //For Serial Number
            e.Graphics.DrawString(
                dataGridView1.Rows[i].Cells[1].FormattedValue.ToString(), 
                new Font("Calibri", 10, FontStyle.Bold), 
                Brushes.Black, 
                new Point(240, y));
        
            //This is for Trim content to next line
            Graphics df1 = e.Graphics;
            SizeF ef1 = df1.MeasureString(
                dataGridView1.Rows[i].Cells[0].FormattedValue.ToString(),
                new Font(new FontFamily("Calibri"), 12F, FontStyle.Bold),
                200); //160
            df1.DrawString(
                dataGridView1.Rows[i].Cells[0].FormattedValue.ToString(),
                new Font(new FontFamily("Calibri"), 12F, FontStyle.Bold), 
                Brushes.Black,
                new RectangleF(new PointF(60.0F, y), ef1), //350.0
                StringFormat.GenericTypographic);
        
            i += 1;
            sno += 1;
            y += 30;
        }
        e.Graphics.DrawString(
            "------------------------------------------------------------------------------------",
            new Font("Calibri", 10, FontStyle.Bold), 
            Brushes.Black, 
            new Point(0, y));
        e.Graphics.DrawString(
            "Total Amount-:" + TotalAmnt_txt.Text, 
            new Font("Calibri", 10, FontStyle.Bold), 
            Brushes.Black, 
            new Point(150, y+=20));
        e.Graphics.DrawString(
            "------------------------------------------------------------------------------------", 
            new Font("Calibri", 10, FontStyle.Bold), 
            Brushes.Black, 
            new Point(0, y+=20));
        e.Graphics.DrawString(
            "***Care For You ****", 
            new Font("Calibri", 10, FontStyle.Bold), 
            Brushes.Black, 
            new Point(150, y += 20));
        i = 0;
        sno = 1;
    }
