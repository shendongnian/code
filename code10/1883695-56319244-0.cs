    public partial class ViewController : UIViewController
        {
    
            public List<Booklist> Bookdata { get; set; }
    
            public ViewController (IntPtr handle) : base (handle)
            {
            }
    
            public override void ViewDidLoad ()
            {
                base.ViewDidLoad ();
                // Perform any additional setup after loading the view, typically from a nib.
    
                Bookdata = new List<Booklist>();
                Bookdata.Add(new Booklist("A2"));
                Bookdata.Add(new Booklist("A3"));
                Bookdata.Add(new Booklist("A1"));
                Bookdata.Add(new Booklist("122"));
                Bookdata.Add(new Booklist("C2"));
                Bookdata.Add(new Booklist("b2"));
    
                List<Booklist> sortedList = Bookdata.OrderBy(r => r.name).ToList();
    
                //pass the sortedList as source of tableview
                //...
            }
        }
    
        public class Booklist
        {
            public Booklist(string n){
                name = n;
            }
    
            public string name;
        }
