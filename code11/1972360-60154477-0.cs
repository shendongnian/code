    public class MainWindowViewModel : ViewModelBase
    {
        public APR InstanceOne { get; set; }
    
        public MainWindowViewModel(){
            InstanceOne = new APR();
        }
    }
