    public class MenuItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  
    	private readonly ICommand _command;
    	public MenuItemViewModel(Action<object> action)
    	{
    		_command = new CommandViewModel(action);
    	}
    
		private string header;
    	public string Header 
		{ 
			get 
			{
				return header;
			}
			set 
			{
				header = value;
				NotifyPropertyChanged();
			}
		}
        private System.Windows.Controls.Primitives.PlacementMode placement;
    	public System.Windows.Controls.Primitives.PlacementMode Placement 
        { 
            get
            {
                return placement;
            }
            set 
            {
                placement = value;
				NotifyPropertyChanged();
            }
        }
    
    	public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
    
    	public ICommand Command
    	{
    		get
    		{
    			return _command;
    		}
    	}
    }
