            var items = GetRoomTypesForPeriod(hotelCode, startDate, endDate);
            var results = items.Select(rt =>
                new RoomTypeDTO
                {
                    id = rt.id,
                    Code = rt.Code,
                    Description = rt.Description,
                    Name = rt.Name,
                    Rooms = rt.Rooms.Select(r =>
                        new RoomDTO
                        {
                            id = r.id,
                            RoomRates = r.RoomRates.Where(rr => rr.EffectiveDate >= startDate &&
                                rr.EffectiveDate <= endDate).ToList()
                        })
                        .Where(r => r.RoomRates.Count == daysRequired)
                        .OrderByDescending(r => r.RoomRates.Count()).ToList()
                });
            return results.ToList();
        }
