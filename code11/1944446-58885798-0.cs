        //The delegate is defined in another part of the code
        //As is the custom EventArgs class
        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
        //external code can only add/remove from this
        //class code can read and fully empty it
        public event PropertyChangedEventHandler PropertyChanged;  
  
        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  
