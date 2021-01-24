    public class StockItem
    {
        public int Quantity;
        public string OriginCountryCode;
        public string StockItemReference;
        public StockItem(int qty, string countryCode, string reference)
        {
            Quantity = qty;
            OriginCountryCode = countryCode;
            StockItemReference = reference;
        }
        public static StockItem Parse(string barcode)
        {
            if (string.IsNullOrEmpty(barcode) || barcode.Length < 7)
            {
                throw new ArgumentException("barcode argument must be at least 7 characters.");
            }
            return new StockItem(GetNumItems(barcode.Substring(barcode.Length - 3)), 
                barcode.Substring(0, 3), barcode.Substring(3, barcode.Length - 6));
        }
        private static int GetNumItems(string pkgCodeQty)
        {
            if (pkgCodeQty == null || pkgCodeQty.Length != 3)
                throw new ArgumentException("pkgCodeQty string must be 3 characters long");
            // Some kind of dictionary that maps a pkgCodeQty type with a count
            var packageCodeMap = new Dictionary<string, int>
            {
                {"PCS", 1},
                {"PKG", 10},
                {"CSE", 50},
                {"PLT", 100}
            };
            foreach (var package in packageCodeMap)
            {
                if (pkgCodeQty.StartsWith(package.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return int.Parse(pkgCodeQty.Substring(package.Key.Length));
                }
            }
            throw new ArgumentException("Unknown pkgCodeQty type specified");
        }
    }
