    public List<RoomType> GetRoomTypes(string hotelCode)
    {
        var results = from rt in _repository.RoomTypes.Include("Rooms.RoomRates")
                      where rt.Rooms.Any(r => r.HotelCode == hotelCode)
                      select rt;
        return results.ToList();
    }
