    public class EastCoastStores : ICoastStore
    {
         private string zip;
    
         public void SetZipCode(string zip)
         { this.zip = zip; }
    
         public string GetZipCode()
         { return zip; }
    }
    
    public class WestCoastStores : ICoastStore
    {
         private string zip;
    
         public void SetZipCode(string zip)
         { this.zip = zip; }
    
         public string GetZipCode()
         { return zip; }
    }
    
    public interface ICoastStore
    {
         void SetZipCode(string zip);
    
         string GetZipCode();
    }
    public class MyGenerics
    {
         private ICoastStore selectedValues;
            
         public MyGenerics(ICoastStore selectedValues)
         {
              this.selectedValues = selectedValues;
         }
         public string GetZipCode()
         {
              return selectedValues.GetZipCode();
         }
     }
    
    static void Main(string[] args)
    {
          EastCoastStores eastCoastStores = new EastCoastStores();
          eastCoastStores.SetZipCode("12345");
          MyGenerics orderAction = new MyGenerics(eastCoastStores);
          var val = orderAction.GetZipCode();
    }
