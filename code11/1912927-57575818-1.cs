    var vehicles = new List<Vehicle>
    {
        new Bus { Name = "Bus", Speed = 180 },
        new Bus { Name = "Bus", Speed = 179 },
        new Bike { Name = "Bus", Speed = 180, Height = 23, Width = 32 },
        new Tram { Name = "Bus", Speed = 23 }
    };
    foreach (var vehicle in vehicles)
    {
        // ..Output vehicle.Name & vehicle.Speed
        if (vehicle is Bike bike)
        {
            // Output bike.Height & bike.Width
        }
    }
