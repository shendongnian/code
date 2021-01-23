    public class MyForm : Form
    {
        DataGrid dataGrid1 = new DataGrid();
        Button printGrid = new Button();
        PrintDocument printDocument1 = new PrintDocument();
        public MyForm()
        {
            printGrid.Click += new EventHandler(printGrid_Click);
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
        }
  
        private void printGrid_Click(System.Object sender, System.EventArgs e)
        {
            printDocument1.Print();
        }
 
        private void printDocument1_PrintPage(System.Object sender, 
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            PaintEventArgs myPaintArgs = 
                new PaintEventArgs(e.Graphics, 
                                   new Rectangle(new Point(0, 0), this.Size));
            this.InvokePaint(dataGrid1, myPaintArgs);
        }
    }
