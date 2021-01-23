    interface IConfigurationView
    {
        event EventHandler SelectConfigurationFile;
    
        void SetConfigurationFile(string fullPath);
        void Show();
    }
    
    class ConfigurationView : IConfigurationView
    {
        Form form;
        Button selectConfigurationFileButton;
        Label fullPathLabel;
    
        public event EventHandler SelectConfigurationFile;
    
        public ConfigurationView()
        {
            // UI initialization.
    
            this.selectConfigurationFileButton.Click += delegate
            {
                var Handler = this.SelectConfigurationFile;
    
                if (Handler != null)
                {
                    Handler(this, EventArgs.Empty);
                }
            };
        }
    
        public void SetConfigurationFile(string fullPath)
        {
            this.fullPathLabel.Text = fullPath;
        }
        public void Show()
        {
            this.form.ShowDialog();        
        }
    }
    
    interface IConfigurationPresenter
    {
        void ShowView();
    }
    
    class ConfigurationPresenter : IConfigurationPresenter
    {
        Configuration configuration = new Configuration();
        IConfigurationView view;
    
        public ConfigurationPresenter(IConfigurationView view)
        {
            this.view = view;            
            this.view.SelectConfigurationFile += delegate
            {
                // The ISelectFilePresenter and ISelectFileView behaviors
                // are implicit here, but in a WinForms case, a call to
                // OpenFileDialog wouldn't be too far fetched...
                var selectFilePresenter = Gimme.The<ISelectFilePresenter>();
                selectFilePresenter.ShowView();
                this.configuration.FullPath = selectFilePresenter.FullPath;
                this.view.SetConfigurationFile(this.configuration.FullPath);
            };
        }
        public void ShowView()
        {
            this.view.SetConfigurationFile(this.configuration.FullPath);
            this.view.Show();
        }
    }
