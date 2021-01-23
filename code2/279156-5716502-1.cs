    public class ListEx
    {
       public List<string> name = new List<string>();
    }
    void StoreName()
    {
      ListEx nm = new ListEx();
      List<string> localList = new List<string>();
    
      localList.Add ( "whatever" );
    
      nm.name = localList;
    }
   
    void StoreNameShort()
    {
      ListEx nm = new ListEx();
      nm.name.Add( "whatever" );
    }
