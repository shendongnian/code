    public class Clock
    {
        private string clockText;
        public string ClockText
        {
            get { return clockText; }
            set
            {
                clockText = value;
                NotifyPropertyChanged(nameof(ClockText));
            }
        }
        public async void ClockLogic()
        {
            while (true)
            {
                ClockText = DateTime.Now.ToString();
                Console.WriteLine(ClockText); // for debug
                await Task.Delay(500);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
