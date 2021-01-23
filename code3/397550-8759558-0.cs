    public class Data : IData
    {
       List<IOther> _mOtherList = new List<Other>();
       public IEnumberable<IOther> OtherList { get { return _mOtherList } }
       
       IOther AddOther()
       {
           return null;
       }
       void RemoveOtherData(IOther data){}
    }
