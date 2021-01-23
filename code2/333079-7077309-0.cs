    var houses = new List<House>(new House[] { myHouse, yourHouse, donaldsHouse });
    // A basic predicate which always returns true:
    Func<House, bool> housePredicate = h => 1 == 1;
    // A room name which you got from user input:
    string userEnteredName = "a Room";
    // Add the room name predicate if appropriate:
    if (!string.IsNullOrWhiteSpace(userEnteredName))
    {
        housePredicate += h => h.MainRoom.Name == userEnteredName;
    }
    // A room type which you got from user input:
    RoomType? userSelectedRoomType = RoomType.Kitchen;
    // Add the room type predicate if appropriate:
    if (userSelectedRoomType.HasValue)
    {
        housePredicate += h => h.MainRoom.Type == userSelectedRoomType.Value;
    }
    // MainRoom.Name = \"a Room\" and Rooms.Count = 3 or 
    // ?????????????????????????
    var aRoomsHouses = houses.AsQueryable<House>().Where(housePredicate);
