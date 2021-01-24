    var str = "I=5212;A=97920;D=20181121|I=5176;A=77360;D=20181117|I=5087;A=43975;D=20181109";
    
    var invoices = str.Trim().Split('|', StringSplitOptions.RemoveEmptyEntries);
    
    foreach (var invoice in invoices)
    {
        var invoiceParts = invoice.Split(';', StringSplitOptions.RemoveEmptyEntries);
    
        var invoiceAmount = decimal.Parse(invoiceParts[1].Trim().Substring(2));
    }
