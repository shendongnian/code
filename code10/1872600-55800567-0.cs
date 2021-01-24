Asp.net
[HttpPost]
        public IActionResult Edit(EditOrderViewModel editOrderViewModel)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.OrderID == editOrderViewModel.OrderId);
            Trailer newTrailer = _context.Trailers.FirstOrDefault(t => t.TrailerID == editOrderViewModel.TrailerId);
            Trailer oldTrailer = _context.Trailers.FirstOrDefault(t => t.TrailerID == order.TrailerId);
            if (ModelState.IsValid)
            {
                order.OrderNumber = editOrderViewModel.OrderNumber;
                order.CustomerId = editOrderViewModel.CustomerId;
                if (oldTrailer.TrailerID != newTrailer.TrailerID)
                {
                    oldTrailer.TrailerStatus = "Available";
                    newTrailer.TrailerStatus = "Unavailable";
                }
                order.TrailerId = newTrailer.TrailerID;
                _context.SaveChanges();
                return Redirect("/Order");
            }
            var orderToEdit = _context.Orders.Include(t => t.Trailer).Include(c => c.Customer).Where(o => o.OrderID == editOrderViewModel.OrderId).SingleOrDefault();
            var trailers = _context.Trailers.Where(x => x.TrailerStatus == "Available" || x.TrailerID == orderToEdit.TrailerId).ToList();
            var customers = _context.Customers.ToList();
            EditOrderViewModel repopulateViewModel = new EditOrderViewModel(orderToEdit, trailers, customers);
            return View(repopulateViewModel);
        }
