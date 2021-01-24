    @page "/radzentest"
    <RadzenDropDown TValue="float" Data="Options"></RadzenDropDown>
    @code {
        List<object> Options = new List<object>();
        protected override void OnInitialized()
        {
            Options.Add(1.1f);
            Options.Add(2.5f);
        }
    }
