     [HttpPost, AllowAnonymous]
        public ActionResult CallPost()
        {
            Notifications notification = new Notifications();
            notification.Message = "And i am iron man!!";
            return PartialView("RightNavigation", notification);
        }
