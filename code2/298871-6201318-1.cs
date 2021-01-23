    public class Stuff
    {
      public void GetHTML(string url, Action<string, Event> callback)
      {
         //Do stuff 
         //raise event
         callback("result here", new Event());       
      }
    }
    stuff.GetHTML(someUrl, HTML_Done);
   
