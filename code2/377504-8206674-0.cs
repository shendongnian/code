    public interface IGestureSink
    {
        void DoGesture();
    }
    public class MyControlVM : INotifyPropertyChanged, IGestureSink
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private ApplicationVM parent;
        public MyControlVM(ApplicationVM parent)
        {
            this.Name = "my user control";
            this.parent = parent;
            parent.PropertyChanged += (s, o) => PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
        }
        public String Name { get; set; }
        public bool Visible { get { return parent.ControlVisible; } }
        public void DoGesture()
        {
            parent.DoGesture();
        }
    }
    public class ApplicationVM : INotifyPropertyChanged, IGestureSink
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ApplicationVM()
        {
            this.ControlVM = new MyControlVM(this);
            this.ControlVisible = false;
        }
        public MyControlVM ControlVM { get; private set; }
        public bool ControlVisible {get; set;}
        public void DoGesture()
        {
            this.ControlVisible = !this.ControlVisible;
            PropertyChanged(this, new PropertyChangedEventArgs("ControlVisible"));
        }
    }
