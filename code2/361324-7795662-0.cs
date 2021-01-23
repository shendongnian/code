    // the interface
    public interface IName {
        string Name { get; set; }
        void DisplayName();
    }
    
    // a class that implements the interface with actual code
    public class NameImpl : IName {
        public string Name { get; set; }
        public void DisplayName() {
            Console.WriteLine(this.Name);
        }
    }
    public class Country : IName {
        
        // instance of the class that actually implements the interface
        IName iname = new NameImpl();
        // forward calls to implementation
        public string Name {
            get { return iname.Name; }
            set { iname.Name = value; }
        }
        public void DisplayName() {
            // forward calls to implementation
            iname.DisplayName();
        }
    }
