    public class ViewModel1 : ProcessStringViewModel
    {
        public ViewModel1()
        {
            // Command gets instantiated 
            this.ProcessMyStringCommand = new RelayCommand(() => this.ProcessMyString());
        }
        internal void ProcessMyString()
        {
        }
    }
