    public class MainWindowViewModel : ViewModel {
    
    	private ICommand loadcommand;
    	public ICommand LoadCommand { get { return loadcommand ?? (loadcommand = new RelayCommand(param => Load())); } }
    
    	private ObservableCollection<ViewModel> items;
    	public ObservableCollection<ViewModel> Items {
    		get {
    			if (items == null) {
    				items = new ObservableCollection<ViewModel>();
    			}
    			return items;
    		}
    	}
    
    	public void Load() {
    		BackgroundWorker bgworker = new BackgroundWorker();
    		bgworker.DoWork += (s, e) => {
    			System.Threading.Thread.Sleep(5000);
                        //dont update here
    			e.Result = new List<ViewModel>();
    		};
    		bgworker.RunWorkerCompleted += (s, e) => {
    			List<ViewModel> result = (List<ViewModel>)e.Result;
    			Items.Clear();
                        //update here
    			Items.Add(result[0]);
    			CommandManager.InvalidateRequerySuggested();
    		};
    		bgworker.RunWorkerAsync();
    	}
    }
