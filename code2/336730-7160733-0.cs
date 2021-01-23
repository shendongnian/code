    Dictionary<int, Hotel> Hotels = new Dictionary<int, Hotel> ();
    while (r.Read()) {
        if (!Hotels.ContainsKey(r["HotelID"])) {
            NewHotel Hotel= new Hotel();
            NewHotel.HotelID = r["HotelID"];
            Newhotel.HotelName = r["HotelName"];
            NewHotel.Rooms = new Dictionary<int, Room> ();
            Hotels.Add(NewHotel);
        }
        Room NewRoom = new Room();
        NewRoom.RoomID = r["RoomName"];
        NewRoom.RoomCode = r["RoomCode"];
        NewRoom.RoomName = r["RoomName"];
        Hotels.Items("HotelID").Rooms.Add(NewRoom);
    }
