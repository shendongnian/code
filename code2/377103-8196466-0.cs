    var record1 = new Record() { userID = 1, itemID = 1, rating = 2 };
    var record2 = new Record() { userID = 1, itemID = 2, rating = 3 };
    var record3 = new Record() { userID = 2, itemID = 3, rating = 1 };
    var records = new List<Record>  { record1, record2, record3 };
    int userID = 1;
    var items = new List<int> { 3, 1 };
    var results = items
    .GroupJoin( records.Where(r => r.userID == userID), item => item, record => record.itemID, (item, record) => new { item, ratings = record.Select(r => r.rating) } )
    .OrderBy( itemRating => itemRating.item)
    .SelectMany( itemRating => itemRating.ratings.DefaultIfEmpty(), (itemRating, rating) => rating);
