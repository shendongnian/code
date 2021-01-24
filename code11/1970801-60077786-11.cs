    public void Refresh()
    {
        // do your updates
        // Update the UI
        InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }
