	var region = new Region(gp1);
	region.Intersect(gp2);
	var gpResult = new GraphicsPath();
	gpResult.AddRectangles(region.GetRegionScans(new Matrix()));
	gpResult.CloseAllFigures();
	using (var br = new SolidBrush(Color.LightYellow))
	{
		e.Graphics.FillPath(br, gpResult);
		//e.Graphics.DrawPath(Pens.Black, gpResult);
	}
