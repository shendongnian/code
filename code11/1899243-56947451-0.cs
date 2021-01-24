 c#
public ActionResult ListYourProduct()
{
    var userId = User.Identity.GetUserId();
    var user = UserManager.FindById(userId);
    var orderItems = db.OrdersItems.Where(x => x.UserName == user.UserName && x.IsHistory == false).ToList();
    return View(orderItems);
}
