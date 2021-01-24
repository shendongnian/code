    public IActionResult Create()
        {
            var model = new NewCustomerviewModel()
            {              
                Customers = new Customers()
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                },
               
            };
            return View(model);
        }
