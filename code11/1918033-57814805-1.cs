    public class MyViewModel : BaseViewModel
    {
        public ICommand FilterOccupationsListCommand { private set; get; }
        ...
        
        public MyViewModel()
        {
           FilterOccupationsListCommand = new Command<string>((NewTextValue) =>
                    {
                        // Pass value to FilterOccupationsList.
                        Console.WriteLine("SearchBar new text --" + NewTextValue);
                        FilterOccupationsList(NewTextValue);
                    });    
        }
        ...
    }
