    public enum CellState
    {
        Dead, Active
    }
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private CellState state;
        public CellState State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged("State");
                NotifyPropertyChanged("Color");
            }
        }
        public Color Color
        {
            get { return state == CellState.Dead ? Colors.Red : Colors.Green; }
        }
    }
    public class ViewModel
    {
        public List<Cell> Cells { get; } = new List<Cell>();
    }
