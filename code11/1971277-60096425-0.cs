public class PartialTableEcpModel
{
	public List<string> Days {get; set;}
	//And so on
}
The Controller
public ActionResult PartialTabelaEcp(string json)
{ 
	PartialTableEcpModel tableModel = new PartialTableEcpModel();
	tableModel.Days = new List<string>() {"Day1", "Day2", Day3};
    var nr_days= 31;
    ViewBag.days= nr_days;
    return PartialView("_TableEve", tableModel);
}
The Razor View
@model PartialTableEcpModel
@foreach(var day in Model.Days)
{
	<p>@day</p>//or whatever
}
so it is again for a Get request
