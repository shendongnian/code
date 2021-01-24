    public partial class BillingDashboard
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        protected override async Task MyFunction()
        {
            JSRuntime.InvokeVoidAsync("generateDashboard");
        }
    }
