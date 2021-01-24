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
            public ActionResult Add(ComplaintTicket imageModel)
            {
                if (imageModel.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                    string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    imageModel.Attachment = "~/Image/" + fileName;
                    string folderPath = Server.MapPath("~/Image/");
                    if (System.IO.File.Exists(folderPath))
                    {
                        fileName = Path.Combine(folderPath, fileName);
                        imageModel.ImageFile.SaveAs(fileName);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                        fileName = Path.Combine(folderPath, fileName);
                        imageModel.ImageFile.SaveAs(fileName);
                    }
                }
                //db.ComplaintTicket.Add(imageModel);
                //db.SaveChanges();
                //ModelState.Clear();
                return View();
            }
    }
