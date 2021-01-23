    public static tbleGreenSheet GetLastInvoice(int empNumber)
    {
        using (var context = new CmoDataContext(Settings.Default.LaCrosse_CMOConnectionString))
        {
            context.Log = Console.Out;
            return context.GetTable<tblGreenSheet>()
                          .Where(gs => gs.InvoiceNumber.Substring(2, 4) == empNumber.ToString())
                          .OrderByDescending(gs => Convert.ToInt32(gs.InvoiceNumber.Substring(6, gs.InvoiceNumber.Length)))
                          .FirstOrDefault();
        }
    }
    public class tbleGreenSheet
    {
        ....
        public int NumericInvoice
        {
            get { return Convert.ToInt32(InvoiceNumber.Substring(6, InvoiceNumber.Length)); }
        }
        ...
    }
