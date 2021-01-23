    public class Stuff 
    {
         public void GetHTML(string url, event to raise here)
         {
            //Do stuff  and instead of raising event here
         }
     } 
    public class Other
     {
         public Other()
         {
             Stuff stuff = new Stuff();
             stuff.GetHTML(someUrl, somehow sending info that HTML_Done should be called);
             //Raise event here once that method is finished
         }
         void HTML_Done(string result, Event e)
         {
              //Do stuff with the result since it's done
         }
     } 
