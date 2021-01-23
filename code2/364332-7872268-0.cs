    public MyTable : ITable
    {
       IList<IItem>ITable List()
       {
          return List().OfType<IItem>().ToList();
       }
    
    
       public List<MyItem> List()
       {
          var l = new List<MyItem>();
          ...
          return l;
       }
    }
