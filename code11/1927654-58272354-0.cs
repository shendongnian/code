    [System.Web.Mvc.HttpPost]
            public ActionResult Save(CustomerViewModel model)
            {
                if (model.Customer.CustomerId == 0)
                { 
                  _context.Customer.Add(model.Customer);
                  _context.SaveChanges();
                }
            }
