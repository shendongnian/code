        class Program {
            static void Main(string[] args) {
                const string sqlStmnt = @"SELECT h.HotelID, h.HotelName, r.HotelRoomID, rt.RoomTypeCode, rt.RoomTypeName FROM Hotel h INNER JOIN HotelRoom r ON r.HotelID = h.HotelID INNER JOIN  RoomType rt ON r.RoomTypeID = rt.RoomTypeID order by h.HotelName, rt.RoomTypeCode";
                var context = new HotelContext();
                var hotelData =  context.Query(sqlStmnt);
                var hotelList = new List<Hotel>();
                //Load our objects
                foreach (dynamic data in hotelData) {
                    int hotelID = data.HotelID;
                    var hotel = hotelList.Where(h => h.HotelID == hotelID).FirstOrDefault()
                                          ?? new Hotel() {HotelName = data.HotelName};
                    hotel.AddRoom(new HotelRoom { HotelRoomID = data.HotelRoomID, RoomType = new RoomType{ TypeCode = data.RoomTypeCode, TypeDescription = data.RoomTypeName}});
                    if (hotel.HotelID != 0) {continue;}
                    hotel.HotelID = hotelID;
                    hotelList.Add(hotel);
                }
                //Display our output
                foreach (var hotel in hotelList) {
                    Console.WriteLine("Hotel Name : " + hotel.HotelName + ", Room Count : " + hotel.HotelRooms.Count());
                    foreach (var room in hotel.HotelRooms) {
                        Console.WriteLine("--" + room.RoomType.TypeCode + ", " + room.RoomType.TypeDescription);
                    }
                }
                
                Console.ReadLine();
             }
        }
