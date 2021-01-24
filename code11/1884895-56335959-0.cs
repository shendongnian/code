    string userid = User.Identity.GetUserId();
    var bookings = db.Bookings
                     .Include(b => b.Customer)
                     .Where(b => b.Customer.Id == userid)
                     .ToList();
    
    return View(bookings);
