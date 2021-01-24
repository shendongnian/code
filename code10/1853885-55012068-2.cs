    public class arch
    {
        public string id { get; set; }
    }
    public class nails
    {
        public string name { get; set; }
    }
    public class Parameter
    {
        public arch arch { get; set; }
        public nails[] nails { get; set; }
        public string token { get; set; }
    }
...
            
            Parameter json = new Parameter
            {
                arch = new arch
                {
                    id = "1"
                },
                nails = new nails[]
                {
                    new nails(){name = "John"}
                },
                token = "randomstuff"
            };
