    public class ClearNameCommand : ICommand
    {
        public bool CanExecute(object parameter, IInputElement target)
        {
            var person = parameter as Person;
            return (person != null && person.Name.Length > 0);
        }
        public void Execute(object parameter, IInputElement target)
        {
            var person = parameter as Person;
            if (person != null)
            {
                person.Name = String.Empty;
            }
        }
    }
