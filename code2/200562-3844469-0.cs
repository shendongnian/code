    public class MyObject() 
    {
        public int number { get; set; }
        public string marker { get; set; }
    }
    IList<MyObject> myobj = new List<MyObject>();
    var orderedList = myobj.OrderBy(x => x.marker).ToList();
