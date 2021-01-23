    public class StringData 
    {
       public StringData(string ID, string TEXT)
       {
          id = ID;
          text = TEXT;
       }
       public string id {get; set;}
       public string text {get; set;}
    }
    
    public class data 
    {
       private Dictionary<string, StringData> dataList;
       public data()
       {
           dataList = new Dictionary<string, StringData>();
       }
    
       public void setObject(string tag, string id, string text)
       {
          dataList[tag] = new StringData(id, text);
       }
    
       public StringData getObject(string tag)
       {
           return dataList[tag]; // Use TryParse for error checking here
       }
    
       public string getID(string tag)
       {
           return dataList[tag].id;  //needs error checking
       }
    
       public string getText(string tag)
       {
           return dataList[tag].text; //needs error checking
       }
    }
