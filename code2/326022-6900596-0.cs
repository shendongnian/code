	GraphPane myPane = zedGraphControl1.GraphPane;
	
	PieItem pieSlice1 = myPane.AddPieSlice(10, Color.Blue, 0F, "Label1");
	PieItem pieSlice2 = myPane.AddPieSlice(15, Color.Orange, 0F, "Label2");
	PieItem pieSlice3 = myPane.AddPieSlice(35, Color.Green, 0F, "Label3");
	PieItem pieSlice4 = myPane.AddPieSlice(40, Color.DarkGray, 0F, "Label4");
	// optional depending on whether you want labels within the graph legend
	myPane.Legend.IsVisible = false;
	
	pieSlice1.LabelType = PieLabelType.None;
	pieSlice2.LabelType = PieLabelType.None;
	pieSlice3.LabelType = PieLabelType.None;
	pieSlice4.LabelType = PieLabelType.None;
	
	zedGraphControl1.AxisChange();
	zedGraphControl1.Invalidate();
	highLine.Symbol.Type = SymbolType.Circle;
	highLine.Symbol.Fill.IsVisible = false;
	highLine.Symbol.Border.Width = 2F;
	highLine.Symbol.Size = 16F;
	
	zedGraphControl1.AxisChange();
	zedGraphControl1.Invalidate();
