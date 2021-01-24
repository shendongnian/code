    var existing = _Entity.MyTable.Select(o => o.Id).ToList();
    foreach (var file in list)
    {
      if (existing.Contains(file.Id))
      {
        _Entity.MyTable.Attach(file);
        _Entity.Entry(file).State = EntityState.Modified;
      }
      else
      {
        _Entity.MyTable.AddObject(file);
      }
    }
    _Entity.SaveChanges();
