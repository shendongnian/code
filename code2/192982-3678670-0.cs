    public class AnswerViewModel : IAnswerViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string content;
    
        public AnswerViewModel()
        {
            PropertyChanged += (sender, args) => DoStuff();
        }
    
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Content"));
            }
        }
    
        public void DoStuff()
        {
            // this method will be called whenever PropertyChanged event raised
        }
    }
