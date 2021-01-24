    switch (apartment.Building)
    {
        case MultiApartmentBuilding maBuilding:
            Console.WriteLine(maBuilding.GroundFloorCount);
            break;
        case Igloo igloo:
            Console.WriteLine(igloo.SnowQuality);
            break;
        default:
            Console.WriteLine("all other building types");
            break;
    }
