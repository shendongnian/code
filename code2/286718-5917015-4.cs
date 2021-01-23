	[Test]
	public void Should_convert_surrounded_low_probability_colors()
	{
		var colors = new List<ColorResult>
			{
				new ColorResult(1, "Unknown", 5f),
				new ColorResult(2, "Blue", 80f),
				new ColorResult(3, "Blue", 80f),
				new ColorResult(4, "Green", 40f),
				new ColorResult(5, "Blue", 80f),
				new ColorResult(6, "Blue", 80f),
				new ColorResult(7, "Red", 20f),
				new ColorResult(8, "Blue", 80f),
				new ColorResult(9, "Green", 5f)
			};
		ConvertSurroundedLowProbabilityColors(colors);
		foreach (var colorResult in colors)
		{
			Console.WriteLine(colorResult.Index + " " + colorResult.Color);
		}
		colors[0].Color.ShouldBeEqualTo("Unknown");
		colors[1].Color.ShouldBeEqualTo("Blue");
		colors[2].Color.ShouldBeEqualTo("Blue");
		colors[3].Color.ShouldBeEqualTo("Blue");
		colors[4].Color.ShouldBeEqualTo("Blue");
		colors[5].Color.ShouldBeEqualTo("Blue");
		colors[6].Color.ShouldBeEqualTo("Red");
		colors[7].Color.ShouldBeEqualTo("Blue");
		colors[8].Color.ShouldBeEqualTo("Green");
	}
