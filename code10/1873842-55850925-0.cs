    public class AxisVM: INotifyPropertyChanged
    {
       public event EventHandler LowerLimitChanged;  
    
       private double lowerLimit;
    
       public double LowerLimit
       {
         get { return lowerLimit }; 
         set { lowerLimit = value; FireOnPropertyChanged(); LowerLimitChanged?.Invoke(this, EventArgs.Empty); }
       }
    }
