    [HttpPost]
    public ActionResult orderUser(User userWithOrder)
    {
        using (myDatabaseEntities myDatabase = new myDatabaseEntities())
        {
            var orderDetails = myDatabase.OrderDetails.Where(a => a.User_ID == userWithOrder.UserID).FirstOrDefault();
            return View(orderDetails)    //It is OK to return from within a using statement; the using will close and dispose as needed.
        }
    }
