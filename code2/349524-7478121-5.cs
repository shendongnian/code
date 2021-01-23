    public void Main()
    {
        HashSet<MyObject> myObjects = new HashSet<MyObject>();
        bool success = myObjects.Add(new MyObject{ID = 1});
        success.Dump("First"); //Returns true
        
        success = myObjects.Add(new MyObject{ID = 1});
        
        success.Dump("Second"); //Returns true should have been false
    }
    
    // Define other methods and classes here
    public class MyObject
    {
        public int ID {get; set;}
    }
