    public class ViewModel : INotifyPropertyChanged
    {
       private AxisVM axis;
    
       public ViewModel()
       {
          this.AxisVM = new AxisVM();
    	  this.AxisVM.LowerLimitChanged += OnLowerLimitChanged;
       }
    
       public AxisVM Axis
       {
         get { return axis}; 
         set { axis = value; FireOnPropertyChanged(); }
       }
    
       public double SomeDouble
       {
         get { return axis.Lowerlimit * 1.5 }; 
       }
       
       public void OnLowerLimitChanged(object sender, EventArgs e)
       {
    	  FireOnPropertyChanged("SomeDouble");
       }
    }
