        public class Hotel{
            private readonly List<HotelRoom> _rooms = new List<HotelRoom>();
            public int HotelID { get; set; }
            public string HotelName { get; set; }
            public void AddRoom(HotelRoom room) {_rooms.Add(room);}
            public IQueryable<HotelRoom> HotelRooms {get {return _rooms.AsQueryable();}}
        }
        public class HotelRoom {
            public int HotelRoomID { get; set; }
            public RoomType RoomType { get; set; }
        }
        public class RoomType {
            public string TypeCode { get; set; }
            public string TypeDescription { get; set; }
        }
  
