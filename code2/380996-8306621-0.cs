         public ContactList ContactList     
         {         
                  get 
                  { 
                           return _contacts; 
                  } 
                  Set
                  {
                           _contacts= value;
                           OnPropertyChnaged("ContactList");
                  }    
         }
