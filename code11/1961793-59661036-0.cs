       [HttpGet]  
            public IActionResult AddEditCustomer(long? id)  
            {  
                CustomerViewModel model = new CustomerViewModel();  
                if (id.HasValue)  
                {  
                    Customer customer = context.Set<Customer>().SingleOrDefault(c => c.Id == id.Value);  
                    if (customer != null)  
                    {  
                        model.Id = customer.Id;  
                        model.FirstName = customer.FirstName;  
                        model.LastName = customer.LastName;  
                        model.MobileNo = customer.MobileNo;  
                        model.Email = customer.Email;  
                    }  
                }  
                return PartialView("~/Views/Customer/_AddEditCustomer.cshtml", model);  
            }  
      
            [HttpPost]  
            public ActionResult AddEditCustomer(long? id, CustomerViewModel model)  
            {  
                try  
                {  
                    if (ModelState.IsValid)  
                    {  
                        bool isNew = !id.HasValue;  
                        Customer customer = isNew ? new Customer  
                        {  
                            AddedDate = DateTime.UtcNow  
                        } : context.Set<Customer>().SingleOrDefault(s => s.Id == id.Value);  
                        customer.FirstName = model.FirstName;  
                        customer.LastName = model.LastName;  
                        customer.MobileNo = model.MobileNo;  
                        customer.Email = model.Email;  
                        customer.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();  
                        customer.ModifiedDate = DateTime.UtcNow;  
                        if (isNew)  
                        {  
                            context.Add(customer);  
                        }  
                        context.SaveChanges();  
                    }  
                }  
                catch (Exception ex)  
                {  
                    throw ex;  
                }  
                return RedirectToAction("Index");  
            }  
