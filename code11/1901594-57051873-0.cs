    @Html.Partial("_PageHeader",
    new WebApplication1.Models.PageHeaderViewModel()
    {
        PageTitle = "Tenant onboarding",
        Buttons = new List<WebApplication1.Models.Button>()
    {
    new WebApplication1.Models.Button
    {
    ButtonTitle = "Add Tenant",
    ButtonAction = "TenantDetails",
    ButtonController = "System",
    ButtonParameters = new { ID = Guid.Empty }.ToString()
    },
    new WebApplication1.Models.Button
    {
    ButtonTitle = "Add Tenant",
    ButtonAction = "TenantDetails",
    ButtonController = "System",
    ButtonParameters = new { ID = Guid.Empty }.ToString()
    },
    new WebApplication1.Models.Button
    {
    ButtonTitle = "Add Tenant",
    ButtonAction = "TenantDetails",
    ButtonController = "System",
    ButtonParameters = new { ID = Guid.Empty }.ToString()
    }
    }
    }
    )
