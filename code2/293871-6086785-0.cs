    MyViewModel : BindableObject // or whatever your base class that implement INotifyPropertyChanged is
    {
        private string eventName;
        public string EventName
        { 
            get{ return eventName; }
            set
            {
                if(value != eventName)
                {
                    eventName = value;
                    FirePropertyChanged(value, "EventName");
                }
            }
        }
        
        private bool checkBoxIsChecked;
        public bool CheckBoxIsCheck
        { 
            get{ return eventName; }
            set
            {
                if(value != eventName)
                {
                    eventName = value;
                    FirePropertyChanged(value, "CheckBoxIsCheck");
                    DoExtraProcessing();
                }
            }
        }   
        private void DoExtraProcessing()
        {
            switch (EventName)
            {
               case "Dogs": // do something
               break;
               case "Cats": // do something else
               break;
            }
        }
    }
