    class Program
    {
    public class Document : System.Drawing.Printing.PrintDocument
    {
        protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
        {
            base.OnBeginPrint(e);
        }
        protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(SystemPens.ActiveBorder, new Rectangle(0, 0, 20, 20));
        }
    }
    
    static void Main(string[] args)
    {
        System.Drawing.Printing.PrintDocument pd = new Document();
        pd.Print();
    }
    
    }
