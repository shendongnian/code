    public class Data : IData
    {
       public IEnumerable<IOther> OtherList { get; private set; }        
       List<Other> _mOtherList = new List<Other>();
    
       public Data()
       {
         OtherList=mOtherList.Cast<IOther>();
       }
    }
