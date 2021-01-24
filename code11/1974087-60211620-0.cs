     public event PropertyChangedEventHandler PropertyChanged;  
        private void OnPropertyRaised(string propertyname) {  
            if (PropertyChanged != null) {  
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));  
            }  
        } 
     
    
       public string SubContent{
           get {..............}
           set {  
                _SubContent = value;  
                OnPropertyRaised("SubContent");
            }  
    }
