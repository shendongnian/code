public abstract class BaseViewModel
{
	protected abstract Dictionary<string, string> Labels { get; }
	public string UserComment { get; set; }
	public string GetLabel(string propName)
	{
		if (!Labels.TryGetValue(propName, out var label))
			throw new KeyNotFoundException($"Label not found for property name: {propName}");
		return label;
	}
}
Then you create the two deriving classes `User` and `Admin`:
public sealed class UserViewModel : BaseViewModel
{
	protected override Dictionary<string, string> Labels => new Dictionary<string, string>
	{
		{ nameof(UserComment), "User label" }
	};
}
public sealed class AdminViewModel : BaseViewModel
{
	protected override Dictionary<string, string> Labels => new Dictionary<string, string>
	{
		{ nameof(UserComment), "Admin label" }
	};
}
They only implement the `Dictionary<string, string>` and set the appropriate text for each field on the base class.
Next, changing your `BaseViewComponent` to this:
**View**:
@model DisplayNameTest.Models.BaseViewModel
<h3>Hello from my View Component</h3>
<!-- Gets the label via the method on the base class -->
<p>@Model.GetLabel(nameof(BaseViewModel.UserComment))</p>
<p>@Model.UserComment)</p>
**ComponentView class (simpler now)**
public IViewComponentResult Invoke(BaseViewModel viewModel)
{
	return View(viewModel);
}
Finally, changing your views `TableView` and `TableManagentView` to this:
@model WebApp.Models.AdminViewModel
@{
    Layout = null;
}
<h1>Admin View</h1>
<div>
    @await Component.InvokeAsync("Base", Model)
</div>
and the Controller to:
public IActionResult Index()
{
	var adminViewModel = new AdminViewModel { UserComment = "some comment from admin" };
	return View(adminViewModel);
}
Now when you navigate to `TableView`, you'll pass a `UserViewModel` to the `BaseViewComponent` and it will figure it out the correct label. Introducing new fields will just now require you to change your viewmodels, adding a new entry to the Dictionary.
It's not perfect, but I think it's an okay way to solve it. I'm by far not an MVC expert so maybe others can come up with a more natural way to do it as well. I also prepared a working sample app and pushed to GitHub. You can check it out here: [aspnet-view-component-demo](https://github.com/joaopgrassi/aspnet-view-component-demo). Hope it helps somehow.
