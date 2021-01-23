    public class ViewModelBindingSource : BindingSource
    {
        private readonly Control _control = new Control();
        private object _viewModel;
        private Type _viewModelType;
        public ViewModelBindingSource()
        {
        }
        
        public ViewModelBindingSource(IContainer container)
            : base(container)
        {
        }
        
        public ViewModelBindingSource(object dataSource, string dataMember)
            : base(dataSource, dataMember)
        {
        }
        public object ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }
        public Type ViewModelType 
        { 
            get { return _viewModelType; }
            set
            {
                if (value != null)
                {
                    // save the type of our viewmodel
                    _viewModelType = value;
                    // create an instance of our viewmodel - so we don't need codebehind
                    _viewModel = Activator.CreateInstance(_viewModelType);
                    // add the viewmodel instance to the internal IList collection of the bindingsource
                    Add(_viewModel);
                    // move to the first element
                    MoveFirst();
                    // set the datasource of the binding source to the first element
                    // this is necessary for data binding of all windows forms controls
                    DataSource = this[0];
                }
            }
        }
        /// <summary>
        /// Pass the call to the main thread for windows forms
        /// This is needed for multithreading support.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (_control != null && _control.InvokeRequired)
                _control.Invoke(new Action<ListChangedEventArgs>(OnListChanged), e);
            else
            {
                base.OnListChanged(e);
            }
        }
