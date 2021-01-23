    public class Stuff
    {
        public void GetHTML(string url, Action callback)
        {
           // Do stuff
    
           // signal we're done 
           callback();
        }
    }
    
    public class Other
    {
        public Other()
        {
            Stuff stuff = new Stuff();
            
            // using a lambda callback
            stuff.GetHTML(someUrl, ()=> Console.WriteLine("Done!") );
            // passing a function directly
            stuff.GetHTML(someUrl, MyCallback);
        }
    
        public void MyCallback() 
        {
            Console.WriteLine("Done!");
        }
    }
