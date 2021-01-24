    if (_context.ProductPins.Where(a => a.ProductId == id && a.Status==false).Count() > 0)
            {
                var c = 0;
                var ProductPins = _context.ProductPins.Where(a=>a.Status==false && a.ProductId == id);
                foreach(var item in ProductPins)
                {
                    ApplicationUser.Balance = ApplicationUser.Balance - product.BuyingPrice;
                    item.Equals(true);
                    _context.Statements.Add(new Statement
                    {
                        Amount = product.BuyingPrice,
                        RecordDate = DateTime.Now,
                        Destination = false,
                        FromApplicationUserId = _userManager.GetUserId(User),
                        //ToApplicationUserId = nu,
                        BalanceType = BalanceType.currentbalance,
                    });
    
                    _context.Update(ApplicationUser);
                    _context.Update(item);
                    
                    c++;
                    if (c > count)
                    {
                        break;
                    }
    
    
    
    
    
                }
    _context.SaveChanges();
