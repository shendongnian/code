    public void Land(Plane plane)
    {
        if (weather.Forecast() == "stormy")
        {
            throw new StormyException("It's too stormy to land");
        }
        if (planes.Count >= _Capacity)
        {
            throw new CapacityException("Airport is full");
        }
        planes.Add(plane);
        Console.WriteLine($"{ plane.Name } has landed at {_AirportName}");
    }
