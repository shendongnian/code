    public ActionResult GetCustomers (string typeOfCustomer)
                {
                    if (string.IsNullOrEmpty(typeOfCustomer))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    if (typeOfCustomer == “archived”)
                    {
                        var customers = _context.Customer.Where(x => x.IsArchived == true).Select(x => x).ToList();
                    }
                    else if (typeOfCustomer == “active”)
                    {
                        var customers = _context.Customer.Where(x => x.IsArchived == false).Select(x => x).ToList();
                    }
                    else
                    {
                        return HttpNotFound();
                    }
        
                    return View(customers);
                }
