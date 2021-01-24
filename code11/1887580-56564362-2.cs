        public ActionResult Index()
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            int diff = ((7 + (today - DayOfWeek.Sunday)) % 7)+1+7;
            DateTime date = DateTime.Now.AddDays(diff*-1);             
            ViewBag.Dates = db.AuditData.OrderBy(m => m.ID).Select(m => m.AuditWeek).Distinct().ToList();
            AuditDataWeekVM adwvm = new AuditDataWeekVM();
            adwvm.AuditWeek = db.AuditData.ToList().Where(x => Convert.ToDateTime(x.AuditWeek) >= date);
            return View(adwvm);
        }
        public ActionResult GetAuditWeek(string dropDownChoice)
        {
            AuditDataWeekVM adwvm = new AuditDataWeekVM();
            adwvm.AuditWeek = db.AuditData.Where(x => x.AuditWeek == dropDownChoice).ToList();
            return View("~/Views/Home/_AuditWeekInfo.cshtml",adwvm);
        }
