    public ActionResult Archive(int? id)
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
    
                customer.IsArchived = true;
    
                return RedirectToAction("Index", "Customers");
    
    
            }
    
    
            public ActionResult GetCustomers(string typeOfCustomer)
            {
                List<Customer> customers = new List<Customer>();
    
                if (string.IsNullOrEmpty(typeOfCustomer))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
    
                if (typeOfCustomer == "archived")
                {
                    customers = _context.Customer.Include(c => c.MembershipType).Where(x => x.IsArchived == true).Select(x => x).ToList();
                }
    
                else if (typeOfCustomer == "active")
                {
                    customers = _context.Customer.Include(c => c.MembershipType).Where(x => x.IsArchived == false).Select(x => x).ToList();
                }
    
                else
                {
                    return HttpNotFound();
                }
    
                return View(customers);
            }
