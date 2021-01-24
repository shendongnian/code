    GoToEditPatientCommand = new RelayCommand(() =>
    {
        if (SelectedPatient.Name != null)
        {
           NavigationService.Navigate("PatientApp.UWP.ViewModels.EditPatientViewModel", SelectedPatient);
          // SelectedPatient = new Patient();
        }
    });
