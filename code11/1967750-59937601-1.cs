    using ReactiveUI;
    
    public class MyViewModel : ReactiveObject
    {
        private string caption;
    
        public string Caption
        {
            get => caption;
            set => this.RaiseAndSetIfChanged(ref caption, value);
        }
    }
