    public class SampleView : System.ComponentModel.INotifyPropertyChanged
    {
    
    	public event PropertyChangedEventHandler System.ComponentModel.INotifyPropertyChanged.PropertyChanged;
    	public delegate void PropertyChangedEventHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e);
    
    	private string _Title;
    	public string Title {
    		get {
    			if (_Title == null) {
    				_Title = My.Settings.MainWindowTitle;
    			}
    			return _Title;
    		}
    		set {
    			_Title = value;
    			if (!(_Title == My.Settings.MainWindowTitle)) {
    				if (PropertyChanged != null) {
    					PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Title"));
    				}
    				My.Settings.MainWindowTitle = Title;
    				My.Settings.Save();
    			}
    		}
    	}
    }
    
