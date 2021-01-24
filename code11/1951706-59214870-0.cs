    public ActionResult Login(User user)
        {
            using (CarsDBEntities db = new CarsDBEntities())
            {
                var usr = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(usr.Email, false);  // add this
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Email"] = usr.Email.ToString();
                    Session["FirstName"] = usr.FirstName.ToString();
                    Session["LastName"] = usr.LastName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is incorrect!");
                }
                return View();
            }
        }
