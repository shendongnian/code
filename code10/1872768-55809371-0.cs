     public ActionResult Login(Login log)
        {
            using (var dbs = new guruEntities())
            {
                var check = dbs.Logins.FirstOrDefault(x => x.Name == log.Name && x.Password == log.Password);
                if (check != null)
                {
                    TempData["UserName"] = check.Name;
                    return RedirectToAction("Success");
                }
                else
                {
                    ViewBag.msg = "Wrong data";
                }
            }
            return View("Login");
        }
