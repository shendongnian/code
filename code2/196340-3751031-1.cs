    List<dbItem> newItems = GetItems(id).Select(x=> new DbItem{ItemNo = x.No,
                                                               ItemName=x.Name})
                                        .ToList();
    db.InsertAllOnSubmit(newItems);
    dc.SubmitChanges();
