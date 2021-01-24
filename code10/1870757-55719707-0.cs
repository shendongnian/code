	var uiTapGesture = new UITapGestureRecognizer(tappedGesture =>
	{
		foreach (MKPolygon polygon in (tappedGesture.View as MKMapView).Overlays)
		{
			using (var render = new MKPolygonRenderer(polygon))
			{
				var coord2D = nativeMap.ConvertPoint(tappedGesture.LocationInView(nativeMap), nativeMap);
				var mapPoint = MKMapPoint.FromCoordinate(coord2D);
				var polyTouched = render.Path.ContainsPoint(render.PointForMapPoint(mapPoint), true);
				if (polyTouched)
					Console.WriteLine($"tapped: {polygon}");
			}
		}
	});
	nativeMap.AddGestureRecognizer(uiTapGesture);
