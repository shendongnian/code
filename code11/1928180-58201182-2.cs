     public  Dictionary<B,string>second;
     public  Dictionary<string,string>Second 
              {
                     get { return second ; }
                     set {
                            second= value;
                            PropertyChanged(this, new PropertyChangedEventArgs("Second"));
                         }
              }
