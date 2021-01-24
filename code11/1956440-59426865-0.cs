using (var db = new Entities())
{
   User user = db.Users.Where(u => u.Id == userIdToBeUpdated).FirstOrDefault();
   user.CardNumber = cardNumber;
   db.SaveChanges();
}
