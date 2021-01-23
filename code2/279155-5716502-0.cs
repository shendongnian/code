    public class ListEx
    {
       public List<string> name = new List<string>();
    }
    string StoreName()
    {
      ListEx nm = new ListEx();
      List<string> localList = new List<string>();
    
      localList.Add ( "whatever" );
    
      nm.name = localList;
    }
