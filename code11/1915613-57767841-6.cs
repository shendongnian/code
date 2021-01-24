    @model IEnumerable<Student>
    @using GridMvc.Html
    
    <script type="text/javascript">
    	function onDdlPageChange(sender) {
    		$("#formIdHere").submit();
    	}
    </script>
    @using (Html.BeginForm("Grid", "Home", FormMethod.Post, new { id = "formIdHere" }))
    {
    	@Html.DropDownList("Page", new SelectList(new Dictionary<string, int> { { "10", 10 }, { "20", 20 }, { "50", 50 } }, "Key", "Value", ViewBag.pageSize), new { id = "pagesizelist", onchange = "onDdlPageChange(this);" })
    
    	@Html.Grid(Model).Columns(Columns =>
    	{
    		Columns.Add(c => c.StudentID).Titled("Id").Filterable(true);
    		Columns.Add(c => c.LastName).Titled("Last name").Filterable(true);
    		Columns.Add(c => c.FirstName).Titled("First name").Filterable(true);
    		Columns.Add(c => c.EnrollmentDate).Titled("Enrollment date").Filterable(true);
    		//Columns.Add();
    	}).WithPaging(ViewBag.pageSize).Sortable(true)
    }
