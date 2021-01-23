    public delegate void DoneEventHandler(object sender, string result);
    
    public class Stuff
    {
        public event DoneEventHandler DoneEvent = delegate {}; // avoid null check later
    
        public void GetHtml(string url)
        {
            // do stuff
            DoneEvent(this, "result");
        }
    }
    
    public class Other
    {
        public void SomeMethod()
        {
            Stuff stuff = new Stuff();
            stuff.DoneEvent += OnDone;
            stuff.GetHtml(someUrl)
        }
    
        public void OnDone(objects sender, string result)
        {
            Console.WriteLine(result);
        }
    }
