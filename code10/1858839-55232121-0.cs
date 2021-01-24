     [HttpGet]
        public ActionResult Info(int id)
        {
            IEnumerable<User> users = db.Users;
            ViewBag.Customers = users;
            var c = new User();
            c.ListMessage = new List<string> { "Test1", "Test2" };
            ViewBag.Messages = c.ListMessage;
            return View(c.ListMessage);
        }
