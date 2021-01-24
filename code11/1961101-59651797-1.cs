    protected override void OnInitialized()
    {
        AppState.OnChange += StateHasChanged;
    }
    public void Dispose()
    {
        AppState.OnChange -= StateHasChanged;
    }
