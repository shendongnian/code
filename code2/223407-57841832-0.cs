    public class ExitCommand : ICommand
    {
        …
        public void Execute(object parameter)
        {
            var windowFacade = parameter as IWindowFacade;
            windowFacade?.Close();
        }
        …
    }
