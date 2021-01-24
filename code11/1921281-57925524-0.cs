         using (var transaction = new TransactionScope())
            {
                var child = await _dbContext.childObject.FindAsync(child.Id);
                if (child != null)
                {
                    _dbContext.Add(child);
                }
                else
                {
                    _dbContext.Entry(child).State = EntityState.Modified;
                }
                await _dbContext.SaveChangesAsync();
                transaction.Complete();
            }
