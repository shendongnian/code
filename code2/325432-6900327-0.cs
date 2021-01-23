	GraphPane myPane = zedGraphControl1.GraphPane;
	
	PointPairList myData = new PointPairList
	{ 
		{1, 1}, {2, 2}, {3, 3}, {4, 4}, {5, 5}
	};
	PointPairList myHighlights = new PointPairList
	{ 
		{double.NaN, double.NaN}, { 2, 2 }, {double.NaN, double.NaN}, { 4, 4 }, {double.NaN, double.NaN}
	};
	
	LineItem dataLine = myPane.AddCurve("Data", myData, Color.Blue);
	LineItem highLine = myPane.AddCurve("Highlight", myHighlights, Color.Red);
	
	dataLine.Symbol.IsVisible = false;
	highLine.Symbol.IsVisible = true;
	
	highLine.Symbol.Type = SymbolType.Circle;
	highLine.Symbol.Fill.IsVisible = false;
	highLine.Symbol.Border.Width = 2F;
	highLine.Symbol.Size = 16F;
	
	zedGraphControl1.AxisChange();
	zedGraphControl1.Invalidate();
