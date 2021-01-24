    public class Example
    {
        public delegate void AsignPropertyChangedEvent(string methodName);
        public delegate void PropertyChanged(object sender, PropertyChangedEventArgs e);
        public Example()
        {
            AsignPropertyChangedEvent += OnAsignPropertyChangedEvent;
        }
        
        public void OnAsignPropertyChangedEvent(string methodName)
        {
            var methodInfo = this.GetType().GetMethod(methodName);
            var handler = Delegate.CreateDelegate(typeof(PropertyChangedEventHandler), this, methodInfo);
            PropertyChanged.AddEventHandler(this, handler);
        }
    }
