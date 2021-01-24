    var mItem = new string[] { "sara", "jhon", "jack" };
    
    public string GetItem (string item)
    {
                
          foreach(var it in mItem)
          {
               if (it == item)
                   return item;
               else
                   return null;
           }
    }
