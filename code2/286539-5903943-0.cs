    public class SavedData<T>{
      private List<T> _nodes;
      private DateTime _saveTime;
    
      public List<T> Nodes{
        get{ return _nodes;}
      }
    
      public DateTime SaveTime{
        get{return _saveTime;}
      }
      
      public SavedData(List<T> nodes, string savedBy){
        _nodes = nodes;
        _savedBy = savedBy;
        _saveTime = DateTime.Now;
      }
    }
