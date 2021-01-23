    public struct DoSomeActionParameters 
    {
       public string A;
       public string B;
       public DateTime C;
       public OtherEnum D;
       public string E;
       public string F;
    }
    public ResultEnum DoSomeAction(DoSomeActionParameters parameters, out Guid code) 
