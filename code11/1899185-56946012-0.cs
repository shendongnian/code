    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string value;
        public string Value
        {
            get { return value; }
            set
            {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
    }
    public class ViewModel
    {
        public Item[] Items { get; } = new Item[20];
        public ViewModel()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new Item();
            }
        }
    }
