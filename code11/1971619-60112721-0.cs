string currency = "EUR:100;INR:500;CZK:500";
string[] strarray= currency.split(';');
List<CurrencyValue> lst= strarray.Select(s=>new CurrencyValue(s.Split(:)[0],s.Split(:)[1]));
foreach(CurrencyValue c in lst)
{
   //Loop through the list
}
    class CurrencyValue 
    {
      public string Currency {get;set;}
      public int Amount{get;set;}
      CurrencyValue(string Curr,int Amt)
      {
        Currency=Curr;
        Amount=Amt;
      }
    }
