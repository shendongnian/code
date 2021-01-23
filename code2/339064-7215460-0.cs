     ObservableEmployee <UIEmployee> list = new ObservableEmployee <UIEmployee>(); //move list to global variables and declare it as ObservableCollection
     public ObservableEmployee GetEmployees()
        {
            
           //here only return an instance of list
           return list;
                    
        }
    
    //this method call when you want to update data on gri
    public void UpdateMyList() {
         //clear list 
         list.Clear();
          
         //after add all data
         list.Ad(..);
         list(..); 
         .
         .
    
    }
