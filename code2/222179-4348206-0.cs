    public GenesisController : Controller
    {
        [CheckLoggedIn(gr = genesisRepository, memberGuid = md.memberGUID)]
        public ActionResult Home(MemberData md)
        {
            return View(md);
        }
    }
