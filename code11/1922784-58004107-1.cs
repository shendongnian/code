        [HttpGet]
        public async Task<Transaction> GetTransaction(Transaction transaction)
        {
            return transaction;
        }
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            transaction = await _context.Transactions.Include(t => t.Account).Include(t => t.Tag).FirstAsync(t => t.Id == transaction.Id);
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }
