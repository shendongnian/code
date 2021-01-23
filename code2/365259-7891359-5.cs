    class MainViewModel
    {
        ObservableCollection<AgreementViewModel> Agreements;
    }
    
    class AgreementViewModel
    { 
        // Loaded only when getter is called
        AgreementDetailViewModel AgreementDetails;
    }
