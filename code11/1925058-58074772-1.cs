public class CrudManuallyController : Controller
{
    public ActionResult Index()
    {
        return View(db.manages.ToList());
        //return View();
    }
    [HttpPost]
    public ActionResult search(int id, string searchString,Student students)
    {
        //Lambda Linq to entity does not support Int32
        //var search = (from d in db.students where d.No == Convert.ToInt32(id) && d.Name == id select d).ToList();
        //var search = db.students.Where(d => d.No == Convert.ToInt32(id) && d.Name == id).ToList();
        query = db.students.Where(d => d.No == id).AsQueryable();
        if (!string.IsNullOrEmpty(searchString))
            query = query.Where(d => d.Name.Contains(searchString));
        var search = query.ToList();
        return View("index",search);
    }
}
update your .cshtml
@using (Html.BeginForm("search", "CrudManually", FormMethod.Post))
{
    @Html.TextBox("id")
    @Html.TextBox("searchString")
    <br/>
    <input type="submit" value="Search"/>
}
