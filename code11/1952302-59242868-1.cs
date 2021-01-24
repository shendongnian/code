    foreach (var process in processes) {
       var dynamictable =
          (from t in _context.PlasticProcess // This table has all types of machines and table names
           where (t.Id == process)
           select t.MachineName
          ).First();
    
        var set = _context.Set(Type.GetType(dynamicTable));
        // use set.SqlQuery here.
    }
