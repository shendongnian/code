    public ActionResult Archive (int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = _context.Customer.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                _context.Customer.IsArchived = true;
    
                _context.SaveChanges();
    
                return RedirectToAction("Index", "Customers");
            }
