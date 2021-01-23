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
			bgworker.WorkerReportsProgress = true;
    		bgworker.DoWork += (s, e) => {
				for(int i=0; i<10; i++) {
					System.Threading.Thread.Sleep(1000);
					bgworker.ReportProgress(i, new List<ViewModel>());
				}
				e.Result = null;
    		};
			bgworker.ProgressChanged += (s, e) => {
				List<ViewModel> partialresult = (List<ViewModel>)e.UserState;
				partialresult.ForEach(i => {
					Items.Add(i);
				});
			};
    		bgworker.RunWorkerCompleted += (s, e) => {
    			//do anything here
    		};
    		bgworker.RunWorkerAsync();
    	}
    }
