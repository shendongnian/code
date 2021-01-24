    <p>@displaystring</p>
    @code {
    string displaystring;
    public void CallChild(string value)
    {
        displaystring = value;
        StateHasChanged();
    }
    }
