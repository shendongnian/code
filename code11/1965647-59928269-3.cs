public class MyBaseModel
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
}
public class ModelA: MyBaseModel{}
public class ModelB: MyBaseModel{}
**View**
Create a single view for the `MyBaseModel` and Put the view in the `Shared` folder and name it something like `MySharedView`:
@model MyNamespace.MyBaseModel
@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>Title which you can decide based on model type or get from ViewBag</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.Property1, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Property1, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Property1, "", new { @class = "text-danger" })
            </div>
        </div>
        ... Rest of properties ...
 
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
}
**Controller**
Then in controllers, when you want to return view, specify the shared view name. For example for model `A` and the same for model `B`:
[HttpGet]
public ActionResult A()
{
    var model = new ModelA() { Property1 = "A", Property2 = "A" };
    return View("MyBaseModel", model);
}
[HttpPost]
public ActionResult A(ModelA model)
{
    // SaveA(model)
    // Redirect to index
}
