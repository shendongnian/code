       private readonly object locker = new object();
       public async Task<string> DecreaseInvByTen()
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                   lock(locker) {
                    var invReduce = _context.Inventorys.Where(w=>w.id == 1).FirstOrDefault(); // availQty is 100.
                    Thread.Sleep(60000); // Goes some long process.
                    invReduce.availQty -= 10;
                    await _context.SaveChangesAsync();
             
                    tran.Commit();
                  }
                    return invReduce.availQty.ToString();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.ToString();
                }
            }
        }
