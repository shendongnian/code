    string cacheKey = "apSpace_GetActiveSpacesForPerson_PersonID:" + personid;
    List<apSpace> list = MemCached.Get<List<apSpace>>(cacheKey);
    if (list == null)
    {
        //Some complex, intensive query...
        list = (from s in BaseDB.apSpaces
                from so in BaseDB.apSpaceOwners
                from sp in BaseDB.apSpacePersons
                where (so.PersonID == personid
                && so.SpaceID == s.SpaceID
                && s.Deleted == false
                && s.IsArchived == false)
                || (sp.PersonID == personid
                && sp.SpaceID == s.SpaceID
                && s.Deleted == false
                && s.IsArchived == false)
                select s).Distinct().OrderBy(s => s.Name).ToList();
        //Cache the query result
        MemCached.Store(cacheKey, list);
    }
    else
        BaseDB.apSpaces.AttachAll(list); //Attach immediately!
    return list;
