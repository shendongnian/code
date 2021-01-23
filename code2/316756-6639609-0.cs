    this.Dispatcher.BeginInvoke((Action)(() =>
    {
        viewModel.LastName = "asdf";
    
        viewModel.LastName = "56udfh";
    
        viewModel.LastName = "09ualkja";
    }),
    DispatcherPriority.DataBind);
