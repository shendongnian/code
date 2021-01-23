    class ViewModel : INotifyPropertyChanged
    {
       public Contact SelectedContact { get .... set ....}
       
       //list of all possible categories (the ones belonging to SelectedContact will have IsChecked true
       public ObservableCollection<CategoryViewModel> Categories 
       {
           get .... set ....
       }   
    }
