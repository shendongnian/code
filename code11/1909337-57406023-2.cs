    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var amendInvoice = await _context.AmendInvoice.Include(a => a.FlatInvoiceItemModels).Where(a => a.Id == id).FirstOrDefaultAsync();
            if (amendInvoice == null)
            {
                return NotFound();
            }
            return View(amendInvoice);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,List<string> Particular,List<int> flatInvoiceItemRid,List<int> flatInvoiceRid,List<int> amount)
        {
            for(var i=0;i<flatInvoiceItemRid.Count();i++)
            {
                var amendInvoice = new FlatInvoiceItemModel(){
                        FlatInvoiceItemRid =flatInvoiceItemRid[i],
                        FlatInvoiceRid=flatInvoiceRid[i],
                        Amount = amount[i],
                        Particular=Particular[i],
                        Id=id
                    };
                _context.Update(amendInvoice);
                await _context.SaveChangesAsync();
            }                                   
            return RedirectToAction(nameof(Index));
            //more logic...
        }
