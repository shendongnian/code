      public int GetID(int ID)
        { 
        return (uow.repo.GetQueryable()
                        .Where(rh => rh.ID == ID && rh.Status == 0)
                        .OrderByDescending(o => o.Rev).First(s => s.ID)); 
        } 
