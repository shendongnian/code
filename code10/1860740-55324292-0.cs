    public ActionResult GetSafeHome(Users_and_Safe uas)
        {
            using (CBREntities2 dc = new CBREntities2())
            {
                var allUAS = dc.Users_and_Safes.Where(b => b.User_ID == User.Identity.Name).Select(c => c.Safe_ID).ToList();
                var homeSafes = dc.Safes.Where(x => (allUAS.Contains(x.Safe_ID))).Select(s => new { Safe_ID = s.Safe_ID, Department_ID = s.Department_ID }).ToList();
                return Json(new { data = homeSafes }, JsonRequestBehavior.AllowGet);
            }
        }
