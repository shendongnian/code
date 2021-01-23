            public void FindTheControls(List<Control> foundSofar, Control parent) 
            {
                
                foreach(var c in parent.Controls) 
                {
                      if(c is IControl) //Or whatever that is you checking for 
                      {
                          foundSofar.Add(c);
                          if(c.Controls.Count > 0) 
                          {
                                this.FindTheControls(foundSofar, c);
                          }
                      }
                      
                     
                }  
            }
