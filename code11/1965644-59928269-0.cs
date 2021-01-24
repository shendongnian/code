public class MyBaseModel
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
}
public class ModelA: MyBaseModel{}
public class ModelB: MyBaseModel{}
**View**
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
