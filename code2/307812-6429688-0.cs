	public class ButtonView : View, INotifyPropertyChanged
	{
	  private UIColor ButtonColor = UIColor.Red;
          
       [Button]
	   [Bind("ButtonColor", "BackgroundColor")]
	   public void Test()
       {
	       ButtonColor = UIColor.Green;
   	       PropertyChanged(this, new PropertyChangedEventArgs("ButtonColor"));
	   }
	   public event PropertyChangedEventHandler PropertyChanged = (s,e)=>{};
    }
