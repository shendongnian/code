    public class DataManager {
      
      List<DataModel> dataCollection = new List<DataModel>();
      
      public void ReadFile() {
        
        // Here you need to read the file and get the values you need.
        // The actual code should be different from what I'm putting here.
        
        foreach(string line in lines) {
          // You get valueOne, valueTwo and valueThree
          // from each line and maybe prepare them 
          // (maybe you need conversion from string to int)
          
          DataModel data = new DataModel(valueOne, valueTwo, valueThree);
          dataCollection.Add(data);
        }
      }
    }
