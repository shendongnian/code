    class MainViewModel
    {
        ObservableCollection<AgreementViewModel> AgreementVMs;
    }
    
    class AgreementViewModel
    { 
        // Loaded only when getter is called
        AgreementDetailViewModel AgreementDetailsVM;
    }
