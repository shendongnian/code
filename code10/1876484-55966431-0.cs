    Connection_fetch_details Connection_fetch_details(String searchName)
    {
        var strLines = File.ReadLines(filePath);
        foreach (var line in strLines)
        {
            if (line.Split(',')[0].Equals(searchName))
            {
                Connection_fetch_details cd = new Connection_fetch_details()
                {
                    username = line.Split(',')[1]
                };
                return cd; //return the object containing the matched username
            }
        }
        return null;
    }
