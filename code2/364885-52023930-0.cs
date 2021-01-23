        public partial class App : Application
        {
            public App()
            {
                var binding = new CommandBinding(MyCommands.DoSomethingCommand, DoSomething, CanDoSomething);
    
                // Register CommandBinding for all windows.
                CommandManager.RegisterClassCommandBinding(typeof(Window), binding);
            }
    
            private void DoSomething(object sender, ExecutedRoutedEventArgs e)
            {
                ...
            }
    
            private void CanDoSomething(object sender, CanExecuteRoutedEventArgs e)
            {
                ...
                e.CanExecute = true;
            }
        }
