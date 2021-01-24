    var customList = await db.MyDbTable
    .Select(x => new { x.Id, x.ParentId, x.Title })
    .ToListAsync();
    private void MyMethod(List<object> inputList)
    {
        //example 
        var item = inputlist.First())
        var id = item.GetType().GetProperty("Id").GetValue(item) //but a lot slower and not recommended
        // process the input list
        return;
    }
