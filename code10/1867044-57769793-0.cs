    	private bool zedGraphControl_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
		{
			var clickedPoint = new PointF(e.X, e.Y);
			var pane = zedGraphControl.MasterPane.FindPane(clickedPoint);
			if (pane == null) return false;
			int index;
			CurveItem outCurve;
			if (!pane.FindNearestPoint(new PointF(e.X, e.Y), out outCurve, out index)) return false;
			if (outCurve.Label.Text == "Needed curve")	//Here you check that user clicked on needed curve
			{
				zedGraphControl.IsEnableHEdit = true;
			}
			return false;
		}
    	private bool zedGraphControl_MouseUpEvent(ZedGraphControl sender, MouseEventArgs e)
		{
			zedGraphControl.IsEnableHEdit = false;
			return false;
		}
