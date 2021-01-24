	var dateStr =  "09.06.2019 00:00:00";
	
	var success = DateTimeOffset.TryParseExact(
			dateStr + " +01:00", // Append the desired timezone to the string
			"dd.MM.yyyy HH:mm:ss zzz", // The format to parse, including Timezone in the end
			null, 
			DateTimeStyles.None, // Strict style. You can also specify how tolerant it is to whitespace
			out DateTimeOffset result // Store it in new variable
		);
		
	if (success)
	{
		// Manipulate into DateTime of different zones.
		Debug.WriteLine(result.DateTime);       // 12am of 09 June 2019
		Debug.WriteLine(result.UtcDateTime);    // 11am the previous day, because result is in UTC+1 timezone
		Debug.WriteLine(result.LocalDateTime);  // Converted to your local timezone
		// You could also pretty much convert into any other zones
		// using the ToOffset() method.
	}
