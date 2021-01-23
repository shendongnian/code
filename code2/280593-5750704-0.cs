     protected void btnPrint_Click(object sender, EventArgs e)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pqr);
                pd.Print();       
            }
    
    
        void pqr(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image i = System.Drawing.Image.FromFile("D:\\Foto.jpg");
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(i, p);     
         }
