    public class AnswerViewModel : IAnswerViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string property1;
        private string property2;
        private string propertyX;
    
        public AnswerViewModel()
        {
            PropertyChanged += (sender, args) => 
            {
                if(args.PropertyName == "Property1" || args.PropertyName == "Property2")
                    DoStuff();
            }
        }
    
        public string Property1
        {
            get { return content; }
            set
            {
                property1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Property1"));
            }
        }
        public string Property2
        {
            get { return content; }
            set
            {
                property2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Property2"));
            }
        }
        public string PropertyX
        {
            get { return content; }
            set
            {
                propertyX = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PropertyX"));
            }
        }
    
        public void DoStuff()
        {
            // this method will be called whenever PropertyChanged event raised from Property1 or Property2
        }
    }
