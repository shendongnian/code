    if (count % 2 > 0)
    {
        result.Add(new Coordinate());
        result[itemIndex].Latitude = System.Convert.ToDouble(reader.Value);
    }
    else
    {
        result[itemIndex].Longitude = System.Convert.ToDouble(reader.Value);
    }
