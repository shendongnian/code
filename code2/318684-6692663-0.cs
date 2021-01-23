    using System.Web.Script.Serialization;
    
    public class Test {
    
       public void DoSomething() {
    
          var jss = new JavaScriptSerializer();
          var dict = jss.Deserialize<Dictionary<string,string>>(jsonText);
    
          Console.WriteLine(dict["some_number"]); //outputs 108.541
    
       }
    }
