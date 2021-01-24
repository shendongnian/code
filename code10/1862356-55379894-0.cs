    private void IterateSave<T>(List<T> items, int min, int max)
    {
        int skip = min;
        int take = max / 5;
        while (skip <= max)
        {
            try
            {
                var subItems = items.Skip(skip).Take(take).ToList();
                _db.Set<T>().AddRange(subItems);
                _db.SaveChanges();
                skip += take;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error saving this data batch! {RecordCount}", take);
                IterateSave(items, skip, take);
            }
        }
    }
