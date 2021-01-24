    public class TapViewModel : INotifyPropertyChanged
    {
        int taps = 0;
        ICommand tapCommand;
        public TapViewModel () {
            // configure the TapCommand with a method
            tapCommand = new Command (OnTapped);
        }
        public ICommand TapCommand {
            get { return tapCommand; }
        }
        void OnTapped (object s)  {
            taps++;
            Debug.WriteLine ("parameter: " + s);
        }
        //region INotifyPropertyChanged code omitted
    }
