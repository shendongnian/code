    var item = await DocumentDBRepository<Customer>.GetCustomerAsync(d => d.Id != null);
                   TempData["item"] = item.ToList();
                    ViewBag.Id = item.Select(d =>d.GroupId);
                    ViewBag.Name = item.Select(d => d.Name);
    
    				List<SelectListItem> ddlcustomer = (from c in item
                            select new SelectListItem
                            {
                                Text = c.Name,
                                Value = c.GroupId,
                            }).ToList();
    						
    						ViewBag.ddlcustomer = ddlcustomer;
