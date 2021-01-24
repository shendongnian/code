    public App()
    {
        Startup += async (s, e) =>
        {
            await ProgramStateViewModel.Instance.LoadDataAndSetupAsync();
        };
    }
