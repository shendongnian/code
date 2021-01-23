	public static float GetLatitude(Image targetImg)
	{
		//Property Item 0x0002 - PropertyTagGpsLatitude
		PropertyItem propItem = targetImg.GetPropertyItem(2);
		return ExifGpsToFloat(propItem);
	}
	public static float GetLongitude(Image targetImg)
	{
		//Property Item 0x0004 - PropertyTagGpsLongitude
		PropertyItem propItem = targetImg.GetPropertyItem(4);
		return ExifGpsToFloat(propItem);
	}
	private static float ExifGpsToFloat(PropertyItem propItem)
	{
		uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
		uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
		uint degrees = degreesNumerator / degreesDenominator;
		uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
		uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
		uint minutes = minutesNumerator / minutesDenominator;
		uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
		uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
		uint seconds = secondsNumerator / secondsDenominator;
		return degrees + (minutes / 60f) + (seconds / 3600f);
	}
