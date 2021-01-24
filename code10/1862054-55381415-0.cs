    // Declare a date range - presumably these would be dynamic not fixed strings
    var startDateTime = DateTime.Parse("2018-09-13 14:19:26.000Z");
    var endDateTime = DateTime.Parse("2018-09-24 14:03:38.000Z");
    // Use the dates to create ObjectId type for comparison
    var startId = new ObjectId(startDateTime, 0, 0, 0);
    var endId = new ObjectId(endDateTime, 0, 0, 0);
    // Use the ObjectId types in the filter
    using (var cursor = await collection.Find(x => x._id > startId && x._id < endId).ToCursorAsync())
    {
        while (await cursor.MoveNextAsync())
        {
            foreach (var doc in cursor.Current)
            {
                // Use doc object
            }
         }
     }
