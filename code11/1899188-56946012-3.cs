    public class ViewModel
    {
        public ObservableCollection<string> Items { get; }
            = new ObservableCollection<string>(
                Enumerable
                    .Range(1, 20)
                    .Select(i => i.ToString())); // or any other initial values
    }
