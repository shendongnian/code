    public ActionResult SignIn(User user)
        {
            User u = db.Users.Where(p=>p.Email == user.Email & p.Password == user.Password).FirstOrDefault();
            if (u == null)
            {
               return View();
            }
            var id = u.Id;
            Session["id_user"] = id;
            return RedirectToAction("Index", "Home");
        }
