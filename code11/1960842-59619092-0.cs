    public Model.FilterOptions GetOptionsById(string filter)
    {
        using (var db = new DLEntities())
        {
              var list = db.Select(item => item);  // Just get the entire list by default 
              // If the filter is provided
              if (! string.IsNullOrWhitespace(filter))
              {
                  // If you cannot insure that your filter is valid...
                  // SomeValidationMethod();
                  // Split the filter string into a list of strings, 
                  // and then parse each of those strings into an int,
                  // returning the whole thing in an anonymous IEnumerable<int>
                  var intFilter = filter.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse);
                  // Finally, filter the list by those integers
                  list = list.Where(item => intFilter.Contains(item.Id));
              }
              // Calling ToList() will finally actually execute the query,
              // either with or without the filter
              return list.ToList();
    }
