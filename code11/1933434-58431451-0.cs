    SpaceObject spaceObject;
    switch (ReadStringFromCellBasedOnHeader("type"))
    {
        case "Asteroid":
            spaceObject = new Asteroid();
            break;
        case "Planet":
            var planet = new Planet();
            spaceObject = planet;
            planet.Name = ReadStringFromCellBasedOnHeader("name");
            planet.Neighbours.AddRange(ReadStringFromCellBasedOnHeader("neighbours").Split(','));
            break;
        default:
            throw new Exception("Unknown SpaceObject Type");
    }
    spaceObject.Position = new Vector2D(ReadDoubleFromCellBasedOnHeader("x"), ReadDoubleFromCellBasedOnHeader("y"));
    spaceObject.Speed = new Vector2D(ReadDoubleFromCellBasedOnHeader("vx"), ReadDoubleFromCellBasedOnHeader("vy"));
    spaceObject.Radius = ReadDoubleFromCellBasedOnHeader("radius");
    spaceObject.Color =
        (Color?)ColorConverter.ConvertFromString(ReadStringFromCellBasedOnHeader("color")) ?? Color.FromRgb(0, 0, 0);
