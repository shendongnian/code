    string GetAddress(ExcelRange rgn, bool absoluteRow, bool absoluteColumn,bool includeSheetName=false)
    {
        string address = rgn.Address;
        if (absoluteColumn)
        {
            address = Regex.Replace(address, @"\b([A-Z])", @"$$$1");
        }
        if (absoluteRow)
        {
            address = Regex.Replace(address, @"([0-9]+)", @"$$$1");
        }
        if (includeSheetName)
        {
            address = $"'{rgn.Worksheet.Name}'!{address}";
        }
        return address;
    }
