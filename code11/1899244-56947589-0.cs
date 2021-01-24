            public ActionResult HistoryOrder(int id)
        {
            string userId = User.Identity.GetUserId();
            var orderList = db.OrdersItems.SingleOrDefault(x => x.OrderItemsId == id);
            orderList.IsHistory = true;
            db.SaveChanges();
            return RedirectToAction("ListYourProduct",userId);
        }
    <a href="@Url.Action("HistoryOrder", "Order", new { id = item.OrderItemsId})">Archiwizuj</a> 
