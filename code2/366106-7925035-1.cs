    [WebMethod]
    public void Method(Invoice[] fields, bool attachmentincluded)
    {
           System.Collections.Generic.List<Invoice> invoices = new List<Invoice>(fields);
            foreach (Invoice i in invoices)
            {
                string N,P;
                int I;
                N =i.PartNumber;
                P = i.Product;
                I = i.InvoiceNumber;
            }
     }
 
