    public class FileListViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Fileinfo> Files{ get; set; }
        private Fileinfo selectedFile;
        public Fileinfo SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile= value;
                InvokePropertyChanged(new PropertyChangedEventArgs("SelectedFile"));
            }
        }
        public PersonListViewModel()
        {
                    //Loading List
                       Files= new ObservableCollection<Fileinfo>()
                  {    //This is temp list you modify accordinh to you logic
                                       new FileInfo{Name = "File32"},
                                       new FileInfo{Name = "File33"},
                                       new FileInfo{Name = "File373"},
                                       new FileInfo{Name = "File393"},
                                       new FileInfo{Name = "File345"},
                                       new FileInfo{Name = "File375"},
                                       new FileInfo{Name = "File395"},
                                       new FileInfo{Name = "File387"},
                                       new FileInfo{Name = "File387"}
                                   };
        }
        #region Implementation of INotifyPropertyChanged
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        #endregion
    }
  
