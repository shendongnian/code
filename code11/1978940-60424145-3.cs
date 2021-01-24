    var customList = await db.MyDbTable
    .Select(x => (Id: x.Id, ParentId: x.ParentId, Title: x.Title ))
    .ToListAsync();
    private void MyMethod(List<(int Id, int ParentId, string Title)> inputList)
    {
        //example 
        var item = inputlist.First())
        var id = item.Id;
        // process the input list
        return;
    }
