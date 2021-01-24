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
            int qty;
            if (string.IsNullOrEmpty(barcode) || barcode.Length < 7 ||
                !int.TryParse(barcode.Substring(barcode.Length - 1, 1), out qty))
            {
                throw new ArgumentException(
                    "barcode argument is not a valid StockItem bar code. " +
                    "Length must be at least 7 and the last digit must be numeric");
            }
            return new StockItem(qty, barcode.Substring(0, 3), 
                barcode.Substring(3, barcode.Length - 6));
        }
    }
