            using (var ts = new TransactionScope())
            {
                using(var tsInner1 = new TransactionScope())
                {
                    //OOPS, I forgot to call Complete() or Rollback()
                }
                using (var tsInner2 = new TransactionScope())
                {
                    //Any db action followed by a "Complete" will cause this error
                    tsInner2.Complete();
                }
            }
