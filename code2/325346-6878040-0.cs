    namespace Faye
    {
       public partial class _Default : System.Web.UI.Page
       {
          public List<String> dtMessages { get; set; } //made property available
          private List<String> LoadMessages()
          {
             var tempList = new List<string>();
             while ((reader.Read()))
             {
                 String temp = reader[0].ToString() + "," + reader[1].ToString() + "," + reader[2].ToString();
                 tempList.Add(temp);
              }
             dtMessages = tempList; //assign the temp list to the property now
          }
       }
    }
