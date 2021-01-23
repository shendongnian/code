        Bitmap MyChartPanel = new Bitmap(panel1.Width, panel1.Height);
        panel1.DrawToBitmap(MyChartPanel, new Rectangle(0, 0, panel1.Width, panel1.Height));
        PrintDialog MyPrintDialog = new PrintDialog();
        if (MyPrintDialog.ShowDialog() == DialogResult.OK)
        {
            System.Drawing.Printing.PrinterSettings values;
            values = MyPrintDialog.PrinterSettings;
            MyPrintDialog.Document = MyPrintDocument;
            MyPrintDocument.PrintController = new System.Drawing.Printing.StandardPrintController();
            MyPrintDocument.Print();
        }
        MyPrintDocument.Dispose();
