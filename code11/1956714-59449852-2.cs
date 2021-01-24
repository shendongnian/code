CS
public IActionResult CreateTask()
{
    ViewBag.Users = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.UserName));
    return View();
}
Task model:
CS
public class TaskModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AssignedTo { get; set; }
    //other properties
}
and in the view
HTML
<div class="form-group">
    <label asp-for="AssignedTo"></label>
    <select asp-for="AssignedTo" asp-items="@ViewBag.Users"></select>
</div>
You could refer to [here][1] for how to populating the Select tag helper .
  [1]: https://stackoverflow.com/a/34624217/10201850
