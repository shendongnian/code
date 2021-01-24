cs
result.AddRange((from mr in moreRooms
                 select new RoomsModel
                 {
                     Type = mr.Type,
                     Size = mr.Size
                 }
                 ).Where(mr => mr.Type == RoomType.BedRoom).ToList());
// also moved the parentheses so that only the filtered list is added via AddRange
