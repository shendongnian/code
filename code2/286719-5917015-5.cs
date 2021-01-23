	private void ConvertSurroundedLowProbabilityColors(IList<ColorResult> colors)
	{
		var surrounding4Modification = new Surrounding4ModificationStrategy();
		foreach (int index in Enumerable
			.Range(0, colors.Count)
			.Where(index => surrounding4Modification.IsMatch(colors, index)))
		{
			surrounding4Modification.Update(colors, index);
		}
	}
