    [STAThread]
    static void Main(string[] args)
    {
        var userInterface  = new UserInterface();
    
        System.Windows.Application app = new System.Windows.Application();
        app.Run(userInterface);
    }
