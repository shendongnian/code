csharp
public List<int> ValidateReferentialIntegrity<TChild, TParent>(string childFilePath, 
    string parentFilePath, 
    Func<TParent, IList<int>, bool> whereFilter,  // <- change #1 is here, IList<int>
    Func<TParent, int> selector) 
{
    var childList = ReadCsvFile<TChild>(typeof(TChild).Name, childFilePath);
    var parentList = ReadCsvFile<TParent>(typeof(TParent).Name, parentFilePath);
    var ids = childList.Select(s => (int)s.GetId()).ToList();
    var unidentifiableIds = parentList
        .Where(p => whereFilter(p, ids))    // <- change #2 is here, pass object to whereFilter
        .Select(selector)
        .ToList();
    return unidentifiableIds;
}
