    foreach (var item in Cars)
    {
        switch (item.Key)
        {
            case "tt77":
            case "tt90":
                {
                    ConfigClasses.Add(
                        item.Key, 
                        new CarsTT(item.Value, item.Value, "", "start"));
                } break;
            case "d8080":
                {
                    ConfigClasses.Add(
                        item.Key, 
                        new Carsd8080(null, new List<string[]>()));
                } break;
            case "d8797":
                {
                    ConfigClasses.Add(
                        item.Key, 
                        new Carsd8080(item.Value));
                } break;
            default: break;
        }
    
    }
