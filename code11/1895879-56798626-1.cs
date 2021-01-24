    public class Rootobject
    {
        public int total { get; set; }
        public string token { get; set; }
        public Result[] results { get; set; }
        public Whatdidido whatdidido { get; set; }
    }
    public class Whatdidido
    {
        public string iretrieved { get; set; }
    }
    public class Result
    {
        public string id { get; set; }
        public Some_Stuff some_stuff { get; set; }
    }
    public class Some_Stuff
    {
        public int aValue { get; set; }
        public int bValue { get; set; }
    }
