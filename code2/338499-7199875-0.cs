    public class PriceList
    {
      DateTime priceTime;
      Double price;
    }
    public class QuoteList
    {
      String symbol;
      String stockName;
      PriceList priceCollection;
    }
    
    List<QuoteList> myQuote = new List<QuoteList>();
