	private void ConvertTrailingLowProbabilityColors(IList<ColorResult> colors)
	{
		var trailingBelow60 = Enumerable
			.Range(0, colors.Count)
			.Select(i => colors.Count - 1 - i)
			.TakeWhile(index => colors[index].Probability < 60)
			.ToList();
		if (trailingBelow60.Count > 0 && trailingBelow60.Count < colors.Count - 2)
		{
			int lastIndex = trailingBelow60.Last();
			var firstPrevious = colors[lastIndex - 1];
			var secondPrevious = colors[lastIndex - 2];
			if (firstPrevious.Probability > 60 &&
			    secondPrevious.Probability > 60 &&
			    firstPrevious.Color == secondPrevious.Color)
			{
				trailingBelow60.ForEach(index => colors[index].Color = firstPrevious.Color);
			}
		}
	}
