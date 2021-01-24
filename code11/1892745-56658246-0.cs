c#
// I just make up the name
public class UpdateSuitViewModel
{
    [Required]
    [Display(Name = "Status")]
    public string SelectedSuitStatus { get; set; }
    public IEnumerable<string> AvailableSuitStatuses { get; set; }
}
###Controller###
In the *controller*, you can build the view model with the data from the database:
c#
public IActionResult Edit()
{
    // Get the statues from the database
    var suitStatuses = ...    
    var vm = new UpdateSuitViewModel
    {
        AvailableSuitStatuses = suitStatuses
    };
    return View(vm);
}
###View###
cshtml
@model UpdateSuitViewModel
<form>
    <select class="form-control"
        asp-for="SelectedSuitStatus"
        asp-items="new SelectList(Model.AvailableSuitStatuses)">
        <option value="">Select Action</option>
    </select>
</form>
The *tag helper* for the dropdown from *ASP.NET CORE* will help you build the dropdown with the name `SelectedSuitStatus` and dropdown options from `AvailableSuitStatuses`;
When you post the form back, the view model `SelectedSuitStatus` will contain the selected dropdown option value!
