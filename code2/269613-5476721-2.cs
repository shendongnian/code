    /// <summary>
    /// A simple ViewModel to demonstrate MVVM
    /// </summary>
    public sealed class ViewModel : DependencyObject, IDataErrorInfo
    {
        #region Properties
        #region DirectoryName
        /// <summary>
        /// The <see cref="DependencyProperty"/> for <see cref="DirectoryName"/>.
        /// </summary>
        public static readonly DependencyProperty DirectoryNameProperty =
            DependencyProperty.Register(
                DirectoryNameName,
                typeof(string),
                typeof(ViewModel),
                new UIPropertyMetadata(null));
        /// <summary>
        /// The name of the <see cref="DirectoryName"/> <see cref="DependencyProperty"/>.
        /// </summary>
        public const string DirectoryNameName = "DirectoryName";
        /// <summary>
        /// 
        /// </summary>
        public object DirectoryName
        {
            get { return (object)GetValue(DirectoryNameProperty); }
            set { SetValue(DirectoryNameProperty, value); }
        }
        #endregion
        #region SelectedFile
        /// <summary>
        /// The <see cref="DependencyProperty"/> for <see cref="SelectedFile"/>.
        /// </summary>
        public static readonly DependencyProperty SelectedFileProperty =
            DependencyProperty.Register(
                SelectedFileName,
                typeof(FileInfo),
                typeof(ViewModel),
                new UIPropertyMetadata(null));
        /// <summary>
        /// The name of the <see cref="SelectedFile"/> <see cref="DependencyProperty"/>.
        /// </summary>
        public const string SelectedFileName = "SelectedFile";
        /// <summary>
        /// 
        /// </summary>
        public FileInfo SelectedFile
        {
            get { return (FileInfo)GetValue(SelectedFileProperty); }
            set { SetValue(SelectedFileProperty, value); }
        }
        #endregion
        /// <summary>
        /// The files found under <see cref="DirectoryName"/>.
        /// </summary>
        public ObservableCollection<FileInfo> Files { get; private set; }
        /// <summary>
        /// Holds the last filename error for IDataErrorInfo
        /// </summary>
        private string _lastDirectoryNameError = null;
        #endregion
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            Files = new ObservableCollection<FileInfo>();
        }
        #endregion
        #region methods
        /// <summary>
        /// Invoked whenever the effective value of any dependency property on this <see cref="T:System.Windows.DependencyObject"/> has been updated. The specific dependency property that changed is reported in the event data.
        /// </summary>
        /// <param name="e">Event data that will contain the dependency property identifier of interest, the property metadata for the type, and old and new values.</param>
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == DirectoryNameProperty)
                UpdateFiles(e.OldValue as string, e.NewValue as string);
        }
        /// <summary>
        /// Updates <see cref="Files"/> when <see cref="DirectoryName"/> changes.
        /// </summary>
        /// <param name="oldDirectoryName">The old value of <see cref="DirectoryName"/></param>
        /// <param name="newDirectoryName">The new value of <see cref="DirectoryName"/></param>
        private void UpdateFiles(string oldDirectoryName, string newDirectoryName)
        {
            if (string.IsNullOrWhiteSpace(newDirectoryName))
            {
                Files.Clear();
                return;
            }
            if (!string.IsNullOrEmpty(oldDirectoryName) &&
                oldDirectoryName.Equals(newDirectoryName, StringComparison.OrdinalIgnoreCase))
                return;
            try
            {
                var di = new DirectoryInfo(Directory.Exists(newDirectoryName) ? newDirectoryName : Path.GetDirectoryName(newDirectoryName));
                // dirty hack
                if (di.ToString().Equals(".", StringComparison.OrdinalIgnoreCase))
                {
                    _lastDirectoryNameError = "Not a valid directory name.";
                    return;
                }
                Files.Clear();
                foreach (var file in di.GetFiles())
                    Files.Add(file);
                _lastDirectoryNameError = null;
            }
            catch (Exception ioe)
            {
                _lastDirectoryNameError = ioe.Message;
            }
        }
        #endregion
        #region IDataErrorInfo
        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        string IDataErrorInfo.Error
        {
            get
            {
                return _lastDirectoryNameError;
            }
        }
        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <returns>The error message for the property. The default is an empty string ("").</returns>
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName.Equals(DirectoryNameName, StringComparison.OrdinalIgnoreCase))
                    return _lastDirectoryNameError;
                return null;
            }
        }
        #endregion
    }
