    var customList = await db.MyDbTable
        .Select(x => Tuple.Create(x.Id, x.ParentId, x.Title))
        .ToListAsync();
    MyMethod(customList);
    
    ...
    
    private void MyMethod(List<Tuple<int, int, string>> inputList)
    {
        // process the input list
        foreach (var item in inputList)
        {
            var id = inputList[0].Item1;
            var parentId = inputList[0].Item2;
            var title = inputList[0].Item3;
        }
        return;
    }
