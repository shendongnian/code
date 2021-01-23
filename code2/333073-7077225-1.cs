            var roomTypeParam = Expression.Parameter(typeof(RoomType), "roomType");
            // ???????????????????????? DOES NOT WORK
            var comparison = Expression.Lambda<Func<House, bool>>(
                Expression.Equal(houseMainRoomTypeParam,
                Expression.Constant(Enum.Parse(typeof(RoomType), "Kitchen"), typeof(RoomType))), houseParam);
                
            
            // ???????????????????????? DOES NOT WORK
            var kitchens = houses.AsQueryable().Where(comparison);
