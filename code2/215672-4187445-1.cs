     public bool Mass
            {
                get { return _mass; }
                set { 
                      // check if value is invalid (0 or less) && that event subscribers exist
                      if(value<=0 && MassChanged != null) { MassChanged(this, null); }
                      else // otherwise assign ...
                      {  
                      _mass = value; 
                      }                
                     
                    }
            }
