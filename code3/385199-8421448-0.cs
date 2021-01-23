    public ObservableCollection<ParserClass> GetCollection(string[] baa)
    {
      var result = new ObservableCollection<ParserClass>();
      foreach(string foo in baa)
      {
        var data = new ParserClass(foo);
        result.Add(data);
      }
      return result;
    }
    public class ParserClass 
    {
      public ParserClass (string baa)
      { 
        //..
      }
    
      public string pro1 
      {
        get { /* etc */ } 
      }
    }
