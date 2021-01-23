    public class ToJson<T>{
    
      public string MyModelToJson (List<T> TheListOfMyModel) {
    
      string ListOfMyModelInJson = "";
    
      JavascriptSerializer TheSerializer = new ....
      TheSerializer.RegisterConverters(....
    
      ListOfMyModelInJson = TheSerializer.Serialize(TheListOfMyModel);
      return ListOfMyModelInJson;
      }
    }
