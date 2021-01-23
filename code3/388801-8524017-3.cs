    public IEnumerable<Room> GetRooms(int areaLargerThan, IEnumerable<Pair> pairs)
    {
        foreach (var p in pairs)
        {
            if (p.One.Area > areaLargerThan) yield return p.One;
            if (p.Two.Area > areaLargerThan) yield return p.Two;
        }
    }
