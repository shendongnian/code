@{ List<ObjectsModel> objects = new List<ObjectsModel>();
    @foreach (var record in objects)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => record.COLUMN1)
            </td>
            <td>
                @Html.DisplayFor(modelItem => record.COLUMN2)
            </td>
            <td>
                @Html.DisplayFor(modelItem => record.COLUMN3)
            </td>
        </tr>
    }
}
to this
public class ObjectsModel : PageModel
{
    public string COLUMN1 { get; set; }
    public string COLUMN2 { get; set; }
    public string COLUMN3 { get; set; }
    public List<ObjectsModel> objects{get; set;}
    public void OnGet()
    {
    }
    public void OnPostGetData(string search)
    {
        DataAccessLayer.GetData(search, out objects);
        return;
    }
}
@{ 
    @foreach (var record in Model.objects)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => record.COLUMN1)
            </td>
            <td>
                @Html.DisplayFor(modelItem => record.COLUMN2)
            </td>
            <td>
                @Html.DisplayFor(modelItem => record.COLUMN3)
            </td>
        </tr>
    }
}
