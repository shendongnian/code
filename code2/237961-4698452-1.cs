        public ActionResult LoginStatus()
        {
            TProfile p = null;
            if (User.Identity.IsAuthenticated)
            {
                p = Data.Profiles.Get(ulong.Parse(User.Identity.Name));
            }
            return View(p);
        }
