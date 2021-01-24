            private ICommand _TextBoxPress;
            public ICommand TextBoxPress
            {
                get { return _TextBoxPress; }
                set { _TextBoxPress = value; this.NotifyPropertyChanged("TextBoxPress"); }
            }
    
            private void TextBoxGotFocus(object obj)
            {
                TestTimer.StopTimer();
                TextBoxPress = null;
            }
