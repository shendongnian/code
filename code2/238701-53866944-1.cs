    public class Rootobject
    {
        public string action { get; set; }
        public string method { get; set; }
        public Element[] elements { get; set; }
    }
    
    public class Element
    {
        public string type { get; set; }
        public string caption { get; set; }
        public Element1[] elements { get; set; }
    }
    
    public class Element1
    {
        public string name { get; set; }
        public string caption { get; set; }
        public string type { get; set; }
        public string placeholder { get; set; }
        public Validate validate { get; set; }
        public string id { get; set; }
        public string _class { get; set; }
        public Options options { get; set; }
    }
    
    public class Validate
    {
        public bool email { get; set; }
        public bool required { get; set; }
        public int minlength { get; set; }
        public Messages messages { get; set; }
        public string equalTo { get; set; }
    }
    
    public class Messages
    {
        public string required { get; set; }
        public string minlength { get; set; }
        public string equalTo { get; set; }
    }
    
    public class Options
    {
        public string f { get; set; }
        public string m { get; set; }
    }
