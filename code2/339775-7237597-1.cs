    private IQueryable<RoomType> QueryRoomTypes(string hotelCode)
    {
        var results = from rt in _repository.RoomTypes.Include("Rooms.RoomRates")
                      where rt.Rooms.Any(r => r.HotelCode == hotelCode)
                      select rt;
        return results;
    }
    public List<RoomType> GetRoomTypes(string hotelCode)
    {
        return this.QueryRoomTypes(hotelCode).ToList();
    }
    public List<RoomType> GetRoomAvailability(string hotelCode, DateTime startDate, DateTime endDate, int daysRequired)
    {
        var items = this.QueryRoomTypes(hotelCode);
        var results = items.Select(rt =>
        // ...
    }
