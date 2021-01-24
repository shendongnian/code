    public List<LookupModel> GetLookupList<T>() where T : class
    {
        try
        {
            using (var context = new TwoCEntities())
            {
                var rows = context.Set<T>();
                return rows.Select(row => new LookupModel
                {
                    Id = (int)row.GetType().GetProperty("Id").GetValue(row, null),
                    Description = row.GetType().GetProperty("Description").GetValue(row, null).ToString()
                }).ToList();
            }
        }
        catch (Exception e)
        {
            if (log.IsErrorEnabled) log.ErrorFormat("GetLookupList<{0}> raised exception {1} with message {2}", typeof(T), e.GetType(), e.Message);
            throw;
        }
    }
