`
   [HttpPost]
        public ActionResult ViewUser(UserViewModel User)
        {
            string UserName = User.UserName;
            string UserSurname = User.UserSurname;
            return View(User);
        }
`
by this
`
[HttpGet]
        public ActionResult ViewUser(UserViewModel User)
        {
            string UserName = User.UserName;
            string UserSurname = User.UserSurname;
            return View(User);
        }
`
