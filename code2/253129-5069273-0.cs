    partial class Detail : INotifyPropertyChanged {
       public decimal Subtotal 
       {
          get
          {
             return Price * Quantity;
          }
       }  
       public event PropertyChangedEventHandler PropertyChanged;
       private void NotifyPropertyChanged(String info)
       {
          if (PropertyChanged != null)
          {
              PropertyChanged(this, new PropertyChangedEventArgs(info));
          }
       }
    }
