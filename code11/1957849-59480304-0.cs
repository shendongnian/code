	// 1. Create a delegate. Example you want to pass an string array
	public delegate void OpenFileCommand(string[] fileNames);
	public class MOpenFileDialog : ViewModelBase
    {
		// 2. Create a event using the delegate in step 1
		public event OpenFileCommand OnOpenFileCommand;
		
		// 3. Raise the event created in step 2 everywhen you want
		public void SomeMethod(string[] fileNames)
		{
			this.OnOpenFileCommand.Invoke(fileNames);
		}
	
        #region Properties
        private OpenFileDialog _openDialog;
        public OpenFileDialog Dialog
        {
            get { return _openDialog; }
            set 
            { 
                _openDialog = value;
                RaisePropertyChanged(nameof(Dialog));
            }
        }
        // some other properties
        #endregion
        #region Constructors
        public MOpenFileDialog()
        {            
            OpenFileCommand = new RelayCommand<object>(OpenFile);
            Dialog = new OpenFileDialog()
            {
                FileName = "Documen",
                Filter = "All Files|*.*",
            };
        }
        #endregion
        #region Methods
        public void OpenFile(object param)
        {
           // somecode
        }
        // some other methods
        #endregion
        #region Commands
        public ICommand OpenFileCommand { get; set; }
        #endregion
    }
	
	public class myClassVM : ViewModelBase
    {
        #region Properties
        public MOpenFileDialog Opendial { get; set; }
        #endregion
        #region Constructor
        public CollectNamesVM()
        {
            Opendial = new MOpenFileDialog() { };
            Opendial.Dialog.Multiselect = true;
            // 4. I cant know what do you want here, but Its same as this
            Opendial.OnOpenFileCommand += CollectFilesFolder(Opendial.Dialog.FileNames); // Wrong Way
        }
        #endregion
        #region Methods
        // 5. CollectFilesFolder has params same as the delegate
        public void CollectFilesFolder(string[] fileNames)
        {
            // toDo
        }
	}
