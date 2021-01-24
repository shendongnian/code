    public class MyViewModel
        {
            public User UserInfo { get; set; }
            public List<Client> Clients { get; set; }
            public string Filter { get; set; }
        }
    [HttpPost]
    [Route("Home/Index")]
    public ActionResult Index(MyViewModel viewmodel)
    {
        return View();
    }
