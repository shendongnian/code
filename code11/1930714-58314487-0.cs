    public class ViewModel : INotifyPropertyChanged
    {
    	public ViewModel()
    	{
    		DeleteModes = new ObservableCollection<DeleteMode>
    		{ DeleteMode.HardDelete, DeleteMode.SoftDelete,
    	      DeleteMode.MoveToDeletedItems };
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	DeleteMode _selected_delete_mode;
    	public DeleteMode SelectedDeleteMode {
    		get { return _selected_delete_mode; }
    		set {
    			_selected_delete_mode = value;
    			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedDeleteMode"));
    		}
    	}
    
    	ObservableCollection<DeleteMode> _delete_modes;
    	public ObservableCollection<DeleteMode> DeleteModes {
    		get { return _delete_modes; }
    		set {
    			_delete_modes = value;
    			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeleteModes"));
    		}
    	}
    
    	public void update_mode(DeleteMode mode) => SelectedDeleteMode = mode;
    }
