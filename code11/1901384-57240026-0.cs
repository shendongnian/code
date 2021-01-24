    List<WorkerTableRow> Search(ItemSearch item, string text)
    {
        string pattern = string.Format("%{0}%", text);
    
        using (var model = new ModelContext())
        {
            IQueryable<Worker> query = model.Workers;
    
            if (item.Value == "FullName")
                query = query.Where(w => EF.Functions.Like(w.FullName, pattern));
    
            if (item.Value == "PassportSeries")
                query = query.Where(w => EF.Functions.Like(w.PassportSeries, pattern));
    
            if (item.Value == "PassportNumber")
                query = query.Where(w => EF.Functions.Like(w.PassportNumber, pattern));
    
            return query.Select(w => new WorkerTableRow { ... }).ToList();
        }
    }
