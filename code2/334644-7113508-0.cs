    var dic = new Dictionary<int, List<Room>>();
    foreach (var hotel in listaHoteisEncontrados)
    {
        if (!dic.ContainsKey(hotel.Id))
        {
            dic.Add(hotel.Id, hotel.Rooms);
        }
        else
        {
            dic[hotel.Id].AddRange(hotel.Rooms);
            //remove duplicate rooms here
        }
    }
