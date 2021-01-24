    bool isduplicated = false;           
    var duplicates = duplicateItems.Select(x => x.VersionId).OrderByDescending(x=>x).ToList();
      if(duplicates.Count >= 2)
        {
         var duplicated = duplicates.Max() - duplicates.Min();
           if(duplicated >= 1)
              {
                isduplicated = true;
              }
        }
