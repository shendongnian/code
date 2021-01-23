    namespace MyApp.Commands
    {
        public class MyApplicationCommands
        {
            public static RoutedUICommand MyCustomCommand 
                                   = new RoutedUICommand("My custom command", 
                                                         "MyCustomCommand", 
                                                         typeof(MyApplicationCommands));
        }
    }
