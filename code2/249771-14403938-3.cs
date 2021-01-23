    private static float? GetLatitude(Image targetImg)
    {
        try
        {
            //Property Item 0x0001 - PropertyTagGpsLatitudeRef
            PropertyItem propItemRef = targetImg.GetPropertyItem(1);
            //Property Item 0x0002 - PropertyTagGpsLatitude
            PropertyItem propItemLat = targetImg.GetPropertyItem(2);
            return ExifGpsToFloat(propItemRef, propItemLat);
        }
        catch (ArgumentException)
        {
            return null;
        }
    }
    private static float? GetLongitude(Image targetImg)
    {
        try
        {
            ///Property Item 0x0003 - PropertyTagGpsLongitudeRef
            PropertyItem propItemRef = targetImg.GetPropertyItem(3);
            //Property Item 0x0004 - PropertyTagGpsLongitude
            PropertyItem propItemLong = targetImg.GetPropertyItem(4);
            return ExifGpsToFloat(propItemRef, propItemLong);
        }
        catch (ArgumentException)
        {
            return null;
        }
    }
    private static float ExifGpsToFloat(PropertyItem propItemRef, PropertyItem propItem)
    {
        uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
        uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
        float degrees = degreesNumerator / (float)degreesDenominator;
        uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
        uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
        float minutes = minutesNumerator / (float)minutesDenominator;
        uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
        uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
        float seconds = secondsNumerator / (float)secondsDenominator;
        float coorditate = degrees + (minutes / 60f) + (seconds / 3600f);
        string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1]  { propItemRef.Value[0] } ); //N, S, E, or W
        if (gpsRef == "S" || gpsRef == "W")
            coorditate = 0 - coorditate;
        return coorditate;
    }
