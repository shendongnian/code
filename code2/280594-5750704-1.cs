    using System.Drawing.Printing;
    ...
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printPage);
            pd.Print();       
        }
    
    
        private void printPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile("D:\\Foto.jpg");
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(ing, loc);     
         }
