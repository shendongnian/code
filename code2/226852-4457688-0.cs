    using System.Web.Script.Serialization; 
    
    public class Person
    {
       public string firstName = "bp";
       public string lastName = "581";
    }
    
    public partial class MyPage : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e) 
       { 
          Person p = new Person();
          string output = JavaScriptObjectSerializer.Serialize(p);
          Response.Write(output);
          Response.Flush();
          Response.End();
       }          
     } 
