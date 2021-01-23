    public class MyObject
    {
        public string Name 
        { 
            get; 
            set; 
        } 
    
        public string EmailAddress
        {
            get; 
            set; 
        } 
    }
    
    IList<string> names = new List<string> { "first name", "second name" };
    IList<MyObject> myObjects = names.Select(x => new MyObject { Name = x }).ToList();
