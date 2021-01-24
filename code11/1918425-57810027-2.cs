    public static class EpplusExtensions
    {
        public static string Address(this ExcelRange rgn, bool absoluteRow, bool absoluteColumn)
        {
            string address = rgn.Address;
            if (absoluteColumn)
            {
                address = Regex.Replace(address, @"\b([A-Z])", @"$$$1");
            }
            if (absoluteRow)
            {
                address = Regex.Replace(address, @"([A-Z])([0-9])", @"$1$$$2");
            }
            return address;
        }
    }
