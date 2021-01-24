    private readony IOverlayViewModel _overlayViewModel;
    public ICommand UpdateCountCommand { get; set; }
    ctor(IOverlayViewModel overlayViewModel)
    {
        _overlayViewModel = overlayViewModel;
        UpdatedCountCommand = new MyICommandImplementation(UpdatedCountCommand_Executed);
    }
    private void UpdatedCountCommand_Executed(/* Add correct method signature */)
    {
        // If needed, retrieve data from parameter...
        // Update overlay ViewModel text
        _overlayViewModel.Text = ""; // Whichever text was calculated before
    }
