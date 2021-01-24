using (TransactionScope main_transaction = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(120)))
            {
                foreach (var attachment in attachmets)
                    attachment.Email = email; // only this line changed
                _emails.InsertOnSubmit(email);
                _context.SubmitChanges();
                main_transaction.Complete();
            }
