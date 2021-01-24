    public interface IFoobar
    {   // these members are all valid
        protected string Protected { get; set; }
        internal string Internal { get; set; }
        static string Static { get; set; }
    }
    
    public class Foobar : IFoobar
    {
        string IFoobar.Protected {get;set;}
        string IFoobar.Internal {get;set;}
    }
