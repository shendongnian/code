public async Task<IActionResult> Withdraw([Bind("ItemId,Qty")] ItemReg itemReg,int quantity) 
        {
            ViewBag.qty = quantity;
            //if (ModelState.IsValid) {
                var itemreg = _context.ItemRegs.Find(itemReg.ItemId);
                itemreg.Qty = itemreg.Qty - ViewBag.qty;
                itemReg.UserName = ViewBag.DisplayName;
                itemreg.UserIP = HttpContext.Connection.RemoteIpAddress.ToString();
                itemreg.UserDate = DateTime.Now.ToString("MM/dd/yyyy");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(itemReg);
        }
I commented the if statement then add the int quantity in the argument.
