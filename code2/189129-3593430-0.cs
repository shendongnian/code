    public interface IData
    {
       string Data1 { get;}
       int MoreData { get;}
    }
    
    class Data : IData
    {
       public string Data1 { get; set;}
       public int MoreData {get; set;}
    }
    
    public class DataObtainer
    {
       private Data[] items;
       public DataObtainer()
       {
          items = new Data[20];
       }
       public IEnumerable<IData> Items
       {
          get
          {
             return items;
          }
       }
     
       public void Update()
       {
          Items[0].MoreData = 5;//Being able to change MoreData
       }
    }
    
    public class AnyOtherClass
    {
       public void SomeMethod()
       {
           DataObtainer do = new DataObtainer();
           //What I want:
           IData di  = do.Items.First();
           Console.WriteLine(di.MoreData);//Being able to read SomeProperty
           di.SomeProperty = 5;//this won't compile
       }
    }
