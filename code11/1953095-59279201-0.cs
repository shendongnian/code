`
<div class="form-horizontal">
    <h4>ComplaintTicket</h4>
    <hr />
    @using (Html.BeginForm("Add", "ComplaintTicket", FormMethod.Post,
                              new { enctype = "multipart/form-data" }))
    { 
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
    <div class="form-group">
        @Html.LabelFor(model => model.Title, htmlAttributes: new { @class = "control-label col-md-2" })
        <div class="col-md-10">
            @Html.EditorFor(model => model.Title, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.Title, "", new { @class = "text-danger" })
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(model => model.Message, htmlAttributes: new { @class = "control-label col-md-2" })
        <div class="col-md-10">
            @Html.EditorFor(model => model.Message, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.Message, "", new { @class = "text-danger" })
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(model => model.Attachment, htmlAttributes: new { @class = "control-label col-md-2" })
        <div class="col-md-10">
            <input type="file" name="ImageFile" required />
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(model => model.Ministry, htmlAttributes: new { @class = "control-label col-md-2" })
        <div class="col-md-10">
            @Html.EditorFor(model => model.Ministry, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.Ministry, "", new { @class = "text-danger" })
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Create" class="btn btn-default" />
        </div>
    </div>
    }
</div>
`
> Controller code
public class ComplaintTicketController : Controller
{
    //CRUDDataComplaintsEntities db = new CRUDDataComplaintsEntities();
    //// GET: ComplaintTicket
    //public ActionResult Index()
    //{
    //    //var tickets = db.ComplaintsTickets.ToList();
    //    var tickets = (from x in db.ComplaintTicket
    //                   join a in db.mins on x.Ministry equals a.Id
    //                   select new TicketsIndexLists() { Id = x.Id, Title = x.Title, Message = x.Message, Attachment = x.Attachment, Name = a.Name }).ToList();
    //    return View(tickets);
    //}
    [HttpGet]
    public ActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Add(ComplaintTicket imageModel,FormCollection formCollection)
    {
        try
        {
           // you can check with Request.Files.Count also
           // if(Request.Files.Count > 0) then your logic to save file
            if(imageModel.ImageFile!=null)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                imageModel.Attachment = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                imageModel.ImageFile.SaveAs(fileName);
            }
            db.ComplaintTicket.Add(imageModel);
            db.SaveChanges();
            ModelState.Clear();
            //after save your return value
        }
        catch(Exception ex)
        {
        }
        return View();
    }
}
