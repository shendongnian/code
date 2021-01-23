	public void ConvertLowProbabilityColors(IList<ColorResult> colors)
	{
		ConvertLeadingLowProbabilityColors(colors);
		ConvertSurroundedLowProbabilityColors(colors);
		ConvertTrailingLowProbabilityColors(colors);
	}
