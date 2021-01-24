    [HttpGet]
        public ActionResult Info(int id)
        {
            User user = db.Users.FirstOrDefault(u => u.Id == id);
            user.ListMessage = new List<string>() { user.Message };
            return View(user.ListMessage);
        }
