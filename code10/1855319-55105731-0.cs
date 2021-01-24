    public void PrepareDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose
        {
            // Finds a ViewType from Mappings
            Type viewType = Mappings[typeof(TViewModel)];
            // Creates a View instance
            IDialog dialog = (IDialog)Activator.CreateInstance(viewType);
            // Adds an event on dialog close request
            EventHandler<DialogCloseRequestedEventArgs> handler = null;
            handler = (sender, e) =>
            {
                // Dispatch handler
                viewModel.CloseRequested -= handler;
                // Reset owner's opacity
                dialog.Owner.Opacity = 1;
                // Returns a result if exists
                if (e.DialogResult.HasValue)
                {
                    dialog.DialogResult = e.DialogResult;
                }
                else
                {
                    dialog.Close();
                }
            };
            dialog.DataContext = viewModel;
            dialog.Owner = owner;
            dialog.Owner.Opacity = 0.5;
            // Adds handler for close request
            viewModel.CloseRequested += handler;
            // Initializes a dialog service in opening dialog's ViewModel if supports it
            IViewModelDialogService viewModelDialogService = viewModel as IViewModelDialogService;
            if (viewModelDialogService != null)
            {
                viewModelDialogService.DialogService = new DialogService((Window)dialog);
            }
            this.newWindow = (Window)dialog;
        }
