    public async Task<IActionResult> MyMethod(Int ID, decimal confirmQty)
        {
            using(var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var invReduce= _context.MyInv.Where(w => w.ID == ID).FirstOrDefault();
                    inventoryReduce.qty -= confirmQty;
        // some long operation too goes here...
                    await _context.SaveChangesAsync();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    // log error if necessary
                }
                return Ok();
        }
