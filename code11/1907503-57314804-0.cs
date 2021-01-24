Private void AddStockItemToList(string barcode)
 {
       string countryCode = barcode.Substring(0, 3);
       string referenceCode = barcode.Substring(barcode.Length - 3);
       stockList.add(new Items(1, countryCode, referenceCode);
   
 }
public class StockItems
{
    public int Quantity;
    public string OriginCountryCode;
    public string StockItemReference
    public Items(int qty, string country, string reference)
    {
       Quantity = qty;
       OriginCountryCode = country;
       StockItemReference = reference;
    }
}
