//model
public int Id { get; set; }
public string Name { get; set; }
public enum MembershipTypes 
    {
    Type1,
    Type2,
    Type3
    }
public MembershipTypes _membershipTypes {get; set; }
//controller
[HttpPost]
public IActionResult Create([Bind("Id","Name","_membershipTypes")] Customers customers)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }    
    Return View(customers);    
}
//view
<div class="row">
    <div class="col-md-6">
        <form asp-action="Create">
            <div class="form-group">
                <label asp-for="Name" class="control-label"></label>
                <input asp-for="Name" class="form-control" />
                <span asp-validation-for="Name" class="text-danger"></span>
            </div>
            <div class="form-group">
                @Html.DropDownList("_membershipTypes",
                    new SelectList(Enum.GetValues(typeof(MembershipTypes))),
                    "Select membership type",
                    new { @class = "form-control" })
            </div>
            <input type="submit" value="Submit!" />
        </form>
    </div>
</div>
