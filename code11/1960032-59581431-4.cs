      public Task<int> SavePrijemAsync(Prijem prijem)
        {
            if (IsExisted(prijem))
            {
                 return _database.UpdateAsync(prijem);
            }
            else
            {
                 return _database.InsertAsync(prijem);
               
            }
        }
