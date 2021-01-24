public void CopyLatestData(DateTime from)
    {
        using (var context = new EdDbContext())
        {
            var query = context.ELMAH_Errors.Where(x => !x.IsCopied).AsQueryable();
            if (query.Count() != 0) //this will check if some are left not copied
            {
                var dataToCopy= query.Take(100).ToList(); //this will only take the first 100
                var result = dataToCopy.Select(x => new parsed_errors(x)).ToList();
            
                context.parsed_errors.AddRange(result);
                dataToCopy.ForEach(x => x.IsCopied = true); //this will update the records to IsCopied = true
                context.SaveChanges();
            }
        }
    }
