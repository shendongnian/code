    private static string MapBathRooms(string value)
    {
        switch (value)
        {
            case "One":
                return "1";
            case "OneAndHalf":
            case "1 1/2":
                return "1.5";
            ...
            default:
                return value;
        }
    }
