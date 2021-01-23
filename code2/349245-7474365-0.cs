    public abstract class AbstractBase : INotifyPropertyChanged
    {
         public virtual event PropertyChangedEventHandler PropertyChanged;
         private void NotifyPropertyChanged(String info)
         {
             if (PropertyChanged != null)
             {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
             }
         }
    }
