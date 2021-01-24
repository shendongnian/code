    public ActionResult Details(int id)
    {
        var currentUserId = User.Identity.GetUserId();
        var deck = _context.Decks.SingleOrDefault(d => d.id == id);
        if (deck == null)
            return HttpNotFound();
        if (deck.UserId != currentUserId)
            return View("Error");
        return View(deck);
    }
