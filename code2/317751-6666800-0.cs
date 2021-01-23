    private Visibility visiMaxTime;         
    public Visibility VisiMaxTime         
    {             
               get { return visiMaxTime; }             
               set             
               {   
                    if (visiMaxTime == value)
                        return;           
                    visiMaxTime = value;                 
                    OnPropertyChanged("VisiMaxTime");   
                    MaxTimeIsChecked = VisiMaxTime == Visibility.Visible;          
                }        
     } 
