	string propString = property.GetValue(this)?.ToString();  // This performs a ToString if property.GetValue() is not null, otherwise propString will be null as well
	if (propString == null)
	{
		propString = string.Empty;
	}
	output.Append(propValue);  // propString is not null
