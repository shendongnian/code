public static void ReOrderTableRecords(Context db)
{
    // By convention do not allow the DB to do the ordering. this type of query will load missing DB values into the current dbContext,  
    // but will not replace the objects that are already loaded.
    // The following query would be ordered by the original DB values:
    //      db.Table.OrderBy(x => x.Order).ToList()
    // Instead we want to order by the current modified values in the db Context. This is a very important distinction which is why I have left this comment in place.
    // So, load from the DB into memory and then order:
    //      db.Table[.Where(...optional filter by parentId...)].ToList().OrderBy(x => x.Order)
    // NOTE: in this implementation we must also ensure that we don't include the items that have been flagged for deletion. 
    var currentValues = db.Table.ToList()
                                .Where(x => db.Entry(x).State != EntityState.Deleted)
                                .OrderBy(x => x.Rank);
    int order = 1;
    foreach (var item in currentValues)
        item.Order = order++;
}
Lets say you can reduce your code to a function that Inserts a new item with a specific Rank into the list or you want to Swap the rank of two items in the list:
public static Table InsertItem(Context db, Table item, int? Rank = 1)
{
    // Rank is optional, allows override of the item.Rank
    if (Rank.HasValue)
        item.Rank = Rank;
    // Default to first item in the list as 1
    if (item.Rank <= 0)
        item.Rank = 1;
    // re-order first, this will ensure no gaps.
    // NOTE: the new item is not yet added to the collection yet
    ReOrderTableRecords(db);
    var items = db.Table.ToList()
                        .Where(x => db.Entry(x).State != EntityState.Deleted)
                        .Where(x => x.Rank >= item.Rank);
    if (items.Any())
    {
        foreach (var i in items)
            i.Rank = i.Rank + 1;
    }
    else if (item.Rank > 1)
    {
        // special case
        // either ReOrderTableRecords(db) again... after adding the item to the table
        item.Rank = db.Table.ToList()
                            .Where(x => db.Entry(x).State != EntityState.Deleted)
                            .Max(x => x.Rank) + 1;
    }
    db.Table.Add(item);
    db.SaveChanges();
    return item;
}
/// <summary> call this when Rank value is changed on a single row </summary>
public static void UpdateRank(Context db, Table item)
{
    var rank = item.Rank;
    item.Rank = -1; // move this item out of the list so it doesn't affect the ranking on reOrder
    ReOrderTableRecords(db); // ensure no gaps
   
    // use insert logic
    var items = db.Table.ToList()
                        .Where(x => db.Entry(x).State != EntityState.Deleted)
                        .Where(x => x.Rank >= rank);
    if (items.Any())
    {
        foreach (var i in items)
            i.Rank = i.Rank + 1;
    } 
    item.Rank = rank;
    db.SaveChanges();
}
public static void SwapItemsByIds(Context db, int item1Id, int item2Id)
{
    var item1 = db.Table.Single(x => x.Id == item1Id);
    var item2 = db.Table.Single(x => x.Id == item2Id);
    var rank = item1.Rank;
    item1.Rank = item2.Rank;
    item2.Rank = rank;
    db.SaveChanges();
}
public static void MoveUpById(Context db, int item1Id)
{
    var item1 = db.Table.Single(x => x.Id == item1Id);
    var rank = item1.Rank - 1;
    if (rank > 0) // Rank 1 is the highest
    {
        var item2 = db.Table.Single(x => x.Rank == rank);
        item2.Rank = item1.Rank;
        item1.Rank = rank;
        db.SaveChanges();
    }
}
public static void MoveDownById(Context db, int item1Id)
{
    var item1 = db.Table.Single(x => x.Id == item1Id);
    var rank = item1.Rank + 1;
    var item2 = db.Table.SingleOrDefault(x => x.Rank == rank);
    if (item2 != null) // item 1 is already the lowest rank
    {
        item2.Rank = item1.Rank;
        item1.Rank = rank;
        db.SaveChanges();
    }
}
> To ensure that Gaps are not introduced, you should call `ReOrder` _after_ removing items from the table, but before calling `SaveChanges()`
>> Alternatively call `ReOrder` before each of Swap/MoveUp/MoveDown similar to insert.
---
Keep in mind that it is far simpler to allow duplicate Rank values, especially for large lists of data, but your business requirements will determine if this is a viable solution.
