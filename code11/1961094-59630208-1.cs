    @code{
    private string _loginVisibility = "visible";
    protected override async Task OnInitializedAsync()
    {
        await TokenExistAsync();
    }
    private async Task TokenExistAsync()
    {
        var retVal = await Http.GetStringAsync("api/Login/ExistToken");
        if (retVal == "yes")
        {
            _loginVisibility = "hidden";
        }
    }
    }
