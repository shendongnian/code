    public class MyViewModel : INotifyPropertyChanged
     {
       private int _Counter = 0;
       public int Counter
       {
         get { return _Counter; }
         set
         {
           _Counter = value;
           OnPropertyChanged(nameof(Counter));
         }
       }
     }
