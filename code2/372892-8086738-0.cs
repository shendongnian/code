    public class YourClass
    {
        public string YourString {get; set;}
        public DateTime YourDate1 {get; set;}
        public DateTime YourDate2 {get; set;}
    
        public YourClass(string s, DateTime d1, DateTime d2)
        {
            YourString = s;
            YourDate1 = d1;
            YourDate2 = d2;
        }
    }
    
    public List<YourClass> Read()
    {
        List<YourClass> list = new List<YourClass>();
        foreach(var item in dataViewer)
            list.Add(new YourClass(s,d1,d2)); // Read variables from item...
        return list;
    }
