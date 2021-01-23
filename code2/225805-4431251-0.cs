    IList<DestinationSummary> list = _invoiceReportDao.InvoiceDestinationSummary(filter);
    IList<DestinationSummary> updatedList = new List<DestinationSummary>(list);
    foreach (DestinationSummary item in updatedList)
    {
        if (item.ChargeCategoryDiscriminator == "INT")
            item.ChargeCategoryDiscriminator = "00%";
        if (item.ChargeCategoryDiscriminator == "UK")
            item.ChargeCategoryDiscriminator = "07%";
    }
