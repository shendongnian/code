public ActionResult Index()
{
	var model = new TestModel
	{
		CompanyTypeId = 1
	};
	ViewBag.Types = new List<SelectListItem>
	{
		new SelectListItem { Value = "-1", Text = "-- Assign Type --" },
		new SelectListItem { Value = "1", Text = "Dummy" },
		new SelectListItem { Value = "2", Text = "Test" },
	};
	return View(model);
}
View
@Html.DropDownListFor(m => m.CompanyTypeId, 
	(ViewBag.Types as List<SelectListItem>),
	new Dictionary<string, object>()
	{
		{ "class", "form-control form-input"},
		{ "Id", "CoType"},
		{ "Name", "CoType"}
	 })
