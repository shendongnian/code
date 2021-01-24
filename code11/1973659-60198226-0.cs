    if (line.Contains("Invoice Number"))
    {
        InvoiceNumbers.Add(line.Replace("Invoice Number", "").Trim());
        break;
    }
