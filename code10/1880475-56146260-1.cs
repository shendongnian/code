    private void UpdateTextBox(string _UpdatePrefix, string _UpdateNumeroDestinataire)
    {
        MainPage mainPage = FindParent<MainPage>(this);
        if (mainPage != null)
        {
            CallSection cellSection = mainPage.CallsSection.Content as CallSection;
            if (cellSection != null)
                cellSection.UpdateEtablissementAppel(_UpdatePrefix, _UpdateNumeroDestinataire);
        }
    }
