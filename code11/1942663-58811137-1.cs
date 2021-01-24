@model Project.Models.membre
@{
  // Write your code here
  model.Name = "Pensum"
}
@using (@Html.BeginForm("Profil", "Membres", FormMethod.Post))
{
    <div>
        @Html.LabelFor(model => model.name)
        @Html.TextBoxFor(model => model.name)
    </div>
}
OR
To assign a value to model.Name in the controller, we should first instantiate an object (membre object) then assign a value to it then pass it to the view.
using Project.Models;
public ActionResult Profil()
{
    // instantiate object
    membre m = new membre();
    // assign value to property
    m.Name = "Pensum";
    // pass to the view
    return View(m);
}
