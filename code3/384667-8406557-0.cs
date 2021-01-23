    private List<T> BuildTypes<T>(XDocument xDocument) where T: EntityValueType
    where T:new()
    {
        var types = 
            (from ty in xDocument.Descendants("RECORD")
             select new T()
                {
                    Id = GenerateGuid(),
                    Name = ty.Element("Name").Value,
                    EntityStatus = _activeEntityStatus,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }).ToList();
    
        return types;
    } 
