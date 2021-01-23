    public class Invoice
    {
    public int InvoiceNumber;
    public string Product, PartNumber;
    public Invoice() { }
 
    public Invoice(string product, string pNumber, int iNumber)
        {
        InvoiceNumber = iNumber;
        Product = product;
        PartNumber = pNumber;
        }
    }
 
