	@model RegistrationViewModel
	@foreach (var item in Model)
	{
		@Html.DropDownListFor(model => model.LicensedState, new SelectList(item.LicenseStates, item.LicenseState))
		@Html.DropDownListFor(model => model.LicenseType, new SelectList(item.LicenseTypes, item.LicenseType))
	}
