class Program {
    static void Main(string[] args) {
        var m = new Messenger { Title = { ForErrors = "An unexpected error occurred ..." } }; // this is allowed
        var t = new Messenger.Titles(); // this is NOT allowed
    }
}
 
public class Messenger {
    public interface ITitles {
        string ForSuccesses { get; set; }
        string ForNotifications { get; set; }
        string ForWarnings { get; set; }
        string ForErrors { get; set; }
    }
 
    private class Titles : ITitles {
        public string ForSuccesses { get; set; }
        public string ForNotifications { get; set; }
        public string ForWarnings { get; set; }
        public string ForErrors { get; set; }
    }
 
    public ITitles Title { get; private set; }
    public Messenger() {
        Title = new Titles();
    }
}
