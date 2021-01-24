    @Html.PartialAsync("_PageHeader", new FliteAdmin.ViewModels.PageHeaderViewModel {
       PageTitle = "Tenant onboarding",
       Buttons = new List<FliteAdmin.ViewModels.Button>() {
            new FliteAdmin.ViewModels.Button() {
                ButtonTitle = "Add Tenant",
                ButtonAction = "TenantDetails",
                ButtonController = "System",
                ButtonParameters = new { ID = Guid.Empty }.ToString()
            }
        }
    })
