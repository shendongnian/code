	var printOptions = Globals.ThisAddIn.Application.ActivePresentation.PrintOptions;
	
	// Set print range type to slides and add some ranges
	printOptions.RangeType = PpPrintRangeType.ppPrintSlideRange;
	printOptions.Ranges.Add(1, 1);
	printOptions.Ranges.Add(3, 5);
