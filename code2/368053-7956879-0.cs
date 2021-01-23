    public interface IData
    {
      bool EqualsTo(IData otherData);
      int GetData();
    }
    public class IntegerData : IData
    {
      int _data;
    
      public int GetData(){
          return _data;
      }
      public IntegerData(int data)
      {
        _data = data;
      }
    
      public bool EqualsTo(IData otherData)
      {
        if(_data.CompareTo(otherData.GetData()) == 0)
            return true;
    
        return false;
      }
    }
