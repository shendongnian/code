    public class MyComparer : IEqualityComparer<DataRow>
    {
       public bool Equals(DataRow x, DataRow y) {
          // logic to distinguish the branches
          // this is just an example.  
          return x["Branch"] == y["Branch"];
           
       }
    
       public int GetHashCode(DataRow obj) {
          // logic to distinguish the branches
          // this is just an example.
          return obj["Branch"].GetHashCode();
       }
    }
    
