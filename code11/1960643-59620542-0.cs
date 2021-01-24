    private IList<myObject> results;
    public IList<myObject> QueryResults
    {
       get
       {
         return results;
       }
       set
       {
         SetProperty(ref results, value);
       }
    }
