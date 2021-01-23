    public GenesisController : Controller
    {
        [CheckLoggedIn()]
        public ActionResult Home(MemberData md)
        {
            return View(md);
        }
    }
