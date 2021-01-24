    var g = Guid.Parse(item.guid);
    var x = _DBcontext.Organizations.FirstOrDefault(o => o.OrgGuid == g);
    if(x == null){
      _DBcontext.Organizations.Add(new Organizations
                    {
                        OrgGuid = g,
                        Name = item.name,
                        CreatedAt = item.created_at,
                        UpdatedAt = item.updated_at,
                        Orghash = tmpmasterhash,
                        Timestamp = DateTime.Now,
                        Foundation = 3
                    });
      await _DBcontext.SaveChangesAsync();
    } else if(tmpmasterhash  != x.Orghash) {
      x.Name = item.name;
      .... //whatever else you want to update
      await _DBcontext.SaveChangesAsync();
    }
    
