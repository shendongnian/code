	object propValue = property.GetValue(this);
	string propString = null;
	if (propValue != null)
	{
		propString = propValue.ToString();
	}
	output.Append(propString);  // propString can be null
