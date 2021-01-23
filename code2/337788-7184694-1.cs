    public class ParamsWrapper
    {
       private NameValueCollection _collection = new NameValueCollection();
       private static ParamsWrapper _instance;
       public static ParamsWrapper Instance {
           if(_instance == null) {
              _instance = new ParamsWrapper(HttpContext.Current.Request.Params);
           }
           
           return _instance;
       }
       public ParamsWrapper(NameValueCollection collection) {
          // added un-duplicated items to _collection from collection;
       }
       // put other methods that you want to interact
       // for example, 
       public string this[string name] {
          get {
              return _collection[name];
          }
       }
    }
