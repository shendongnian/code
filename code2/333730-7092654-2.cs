    using Microsoft.Research.DynamicDataDisplay;
	using System.Collections.ObjectModel;
	using Microsoft.Research.DynamicDataDisplay.DataSources;
	public void ClearLines()
	{
		var lgc = new Collection<IPlotterElement>();
		foreach (var x in plotter.Children)
		{
			if (x is LineGraph || x is ElementMarkerPointsGraph)
				lgc.Add(x);
		}
		foreach (var x in lgc)
		{
			plotter.Children.Remove(x);
		}
	}
	internal void SendToGraph() {
		IPointDataSource _eds = null;
        LineGraph line;
	
		ClearLines();
		EnumerableDataSource<StochasticProcessPoint> _edsSPP;
		_edsSPP = new EnumerableDataSource<StochasticProcessPoint>(myListOfStochasticProcessPoints);
		_edsSPP.SetXMapping(p => dateAxis.ConvertToDouble(p.t));
		_edsSPP.SetYMapping(p => p.value);
		_eds = _edsSPP;
		
		line = new LineGraph(_eds);
		line.LinePen = new Pen(Brushes.Black, 2);
		line.Description = new PenDescription(Description);
		plotter.Children.Add(line);
		plotter.FitToView();
	}
