        public ActionResult ApproveUser(int userId)
        {
            var user = context.Users.Find(userId);
            if(user != null)
            {
                user.ApproveStatus = 1;
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return View();
        }
