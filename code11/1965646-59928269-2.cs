public class MyBaseModel
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
}
public class ModelA: MyBaseModel{}
public class ModelB: MyBaseModel{}
**View**
Put the view in the `Shared` folder and name it something like `MySharedView`.
@model MyNamespace.MyBaseModel
@using (Html.BeginForm())
{
    <div class="form-body">
        @Html.AntiForgeryToken()
        <div class="form-group">
            @Html.LabelFor(model => model.Property1)
            <div class="input-group col-md-4">
                @Html.EditorFor(model => model.Property1)
                @Html.ValidationMessageFor(model => model.Property1)
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(model => model.Property2)
            <div class="input-group col-md-4">
                @Html.EditorFor(model => model.Property2)
                @Html.ValidationMessageFor(model => model.Property2)
            </div>
        </div>
    </div>
}
**Controller**
Then in controllers, when you want to return view:
public class MyController : Controller
{
    public ActionResult A()
    {
        var model = new ModelA() { Property1 = "A", Property2 = "A" };
        return View("MyBaseModel", model);
    }
    public ActionResult B()
    {
        var model = new ModelB() { Property1 = "B", Property2 = "B" };
        return View("MyBaseModel", model);
    }
}
