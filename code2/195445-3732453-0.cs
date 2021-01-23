    public class MainViewModel : ViewModelBase
    {
      public DelegateCommand<object> RunCommand { get; set; }
      public DelegateCommand<object> OkCommand { get; set; }
      private bool enableOk = false;
      private bool setOK = false;
      private ObservableCollection<MyEntity> _entites = new ObservableCollection<MyEntity>();
    
      public MainViewModel()
      {
         _entites.CollectionChanged += (s, e) =>
         {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
               // handle property changing
               foreach (MyEntity item in e.NewItems)
               {
                  ((INotifyPropertyChanged)item).PropertyChanged += (s1, e1) => { if (setOK) enableOk = true; };
               }
            }
            // handle collection changing
            if (setOK) enableOk = false;
         };
      
         MyEntity me1 = new MyEntity { Name = "Name", Information = "Information", Details = "Detials" };
         MyEntity me2 = new MyEntity { Name = "Name", Information = "Information", Details = "Detials" };
         MyEntity me3 = new MyEntity { Name = "Name", Information = "Information", Details = "Detials" };
         _entites.Add(me1);
         _entites.Add(me2);
         _entites.Add(me3);
     
         // allow collection changes now to start enabling the ok button...
         setOK = true;
    
         RunCommand = new DelegateCommand<object>(OnRunCommnad, CanRunCommand);
         OkCommand = new DelegateCommand<object>(OnOkCommnad, CanOkCommand);
      }
     
      private void OnRunCommnad(object obj)
      {
         MyEntity me = new MyEntity { Name = "Name", Information = "Information", Details = "Detials" };
         // causes ok to become enabled
         _entites.Add(me);
         MyEntity first = _entites[0];
         // causes ok to become enabled
         first.Name = "Zamboni";
      }
    
      private bool CanRunCommand(object obj)
      {
         return true;
      }
    
      private void OnOkCommnad(object obj)
      {
      }
    
      private bool CanOkCommand(object obj)
      {
         return enableOk;
      } 
    }
