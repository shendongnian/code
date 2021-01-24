    public static void PutInvoice(Invoice invoice)
    {
        var existingInvoice = FindInvoice(invoice.RefNumber);
        if (existingInvoice != null)
        {
            existingInvoice.QBXMLVersion = "12.0";
            existingInvoice.RuntimeLicense = "MyRuntimeLicenseKey";
            existingInvoice.QBConnectionString = "MYCONNECTIONSTRINGTOREMOTECONNECTOR";
            existingInvoice.LineItems.Clear();
            existingInvoice.LineItems.AddRange(invoice.LineItems);
            existingInvoice.Update(); 
        }
    }
