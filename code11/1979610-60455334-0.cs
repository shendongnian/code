        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                purchase = dbContext.Purchases.Include(x => x.Store).FirstOrDefault(x => x.ID == purchase.ID); // Not sure why you need Store information at this step.
                return RedirectToAction("Index");
            }
            return View(purchase);
        }
