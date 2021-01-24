        private void Button1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintImage);
            PrintDialog printdlg = new PrintDialog();
    
            /*preview the assigned document or you can create a different previewButton for it
            printPrvDlg.Document = pd;
            printPrvDlg.ShowDialog(); // this shows the preview and then show the Printer Dlg below
            */
            printdlg.Document = pd;
    
            if (printdlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
    
    void PrintImage(object o, PrintPageEventArgs e)
    {
        const int ORIGIN = 150;
        var near = new StringFormat() { Alignment = StringAlignment.Near };
        var centered = new StringFormat() { Alignment = StringAlignment.Center };
        var far = new StringFormat() { Alignment = StringAlignment.Far };
        Point tempPoint = new Point();
        var rect = new RectangleF(0, 0, 0, 0);
        var headingRect = new RectangleF(0, 0, 0, 0);
        // Create font and brush.
        Font titleDrawFont = new Font("Times New Roman", 16, FontStyle.Bold);
        Font subtitleDrawFont = new Font("Times New Roman", 12);
        Font drawFont = new Font("Times New Roman", 8);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Pen blackPen = new Pen(Color.Black, 1);
    
        // Draw string to screen.          
        //***************************************************************
    
        Image logo = Image.FromFile(imageLoc);
        e.Graphics.DrawImage(logo, (e.PageBounds.Width - logo.Width) / 2,
                                    10, logo.Width, logo.Height); //Created Centered Image in original size
        rect.Width = 150;
        rect.Height = 20;
        headingRect.Width = e.PageBounds.Width;
        headingRect.Height = 40; //Set to 40 to avoid cut off with larger title text
        tempPoint.X = 0;
        tempPoint.Y = 110;
        headingRect.Location = tempPoint;
        e.Graphics.DrawString(lblTitle.Text, titleDrawFont, drawBrush, headingRect, centered);
