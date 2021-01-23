    public class ViewModel : ViewModelBase
    {
        private int m_CurrentProgress;
        private int m_MethodCount;
    
        // Bind this to the progress bar
        public int CurrentProgress
        {
            get { return m_CurrentProgress; }
            set
            {
                m_CurrentProgress = value;
                OnPropertyChanged("CurrentProgress");
            }
        }
    
        // Bind this to the progress bar
        public int MethodCount
        {
            get { return m_MethodCount; }
            set
            {
                m_MethodCount = value;
                OnPropertyChanged("MethodCount");
            }
        }
    
        private void MethodExecuted(object sender, EventArgs e)
        {
            CurrentProgress++;
        }
    
        public void Run()
        {
            var c = new ExternalClass();
            MethodCount = c.Methods.Count;
            c.MethodExecuted += MethodExecuted;
    
            c.Run(null);
        }
    }
    
    public class ExternalClass
    {
        public List<object> Methods { get; set; }
    
        public event EventHandler<EventArgs> MethodExecuted;
    
        public void InvokeMethodExecuted(EventArgs e)
        {
            EventHandler<EventArgs> handler = MethodExecuted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    
        public void Run(object item)
        {
            foreach (var method in Methods)
            {
                method(item);
    
                InvokeMethodExecuted(null);
            }
        }
    }
