    public ActionResult Details(int id)
            {
                var cards = _context.Cards.SingleOrDefault(c => c.Id == id);
                var decks = _context.Decks.ToList();
    
                var viewModel = new DeckCardViewModel
                {
                    
                   Cards = cards,
                   Decks = decks
            };
    
                return View(viewModel);
            }
