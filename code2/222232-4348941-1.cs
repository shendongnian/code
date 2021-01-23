    public class Application {
        public ExistingEmployee Employee { get; }
    }
    public class NewApplication {
        public NewEmployee Employee { get; }
    }
    ...
    Application app = new Application;
    var emp = app.Employee; // this will be of type ExistingEmployee!
