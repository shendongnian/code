    public class RoutedCommand : ICommand
    {
        public void Execute(object parameter, IInputElement target)
        {
            // ...
        }
        // explicit interface implementation of ICommand.Execute
        void ICommand.Execute(object parameter)
        {
            // ...
        }
    }
