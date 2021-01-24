		private void UpdateResizeArea(Point currentMousePoint)
		{
               :
               :
            switch (_activeResizeAreaSide)
            {
                case SelectionArea.ResizeSide.LEFT:
                    {
                        _activeResizeArea.OffsetX = _activeResizeAreaXbeforeStart + deltaX;
                        _activeResizeArea.AreaWidth = _activeResizeAreaWidthbeforeStart - deltaX;
                        var tg = new TransformGroup();
                        var rad = _activeResizeArea.Rotation * Math.PI / 180;
                        var cx = _activeResizeArea.CalculateCenterPoint().X - _activeRotateAreaCenterPointBeforeStart.X;
                        var cy = _activeResizeArea.CalculateCenterPoint().Y - _activeRotateAreaCenterPointBeforeStart.Y;
                        var tx = cx * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d + cy * Math.Sin(rad);
                        var ty = cx * Math.Sin(rad) - cy * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d;
                        var t = new TranslateTransform(-tx, ty);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
                case SelectionArea.ResizeSide.TOP:
                    {
                        _activeResizeArea.OffsetY = _activeResizeAreaYbeforeStart + deltaY;
                        _activeResizeArea.AreaHeight = _activeResizeAreaHeightbeforeStart - deltaY;
                        var tg = new TransformGroup();
                        var rad = _activeResizeArea.Rotation * Math.PI / 180;
                        var cx = _activeResizeArea.CalculateCenterPoint().X - _activeRotateAreaCenterPointBeforeStart.X;
                        var cy = _activeResizeArea.CalculateCenterPoint().Y - _activeRotateAreaCenterPointBeforeStart.Y;
                        var tx = cy * Math.Sin(rad) + cx * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d;
                        var ty = cy * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d - cx * Math.Sin(rad);
                        var t = new TranslateTransform(-tx, -ty);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
                case SelectionArea.ResizeSide.RIGHT:
                    {
                        _activeResizeArea.AreaWidth = _activeResizeAreaWidthbeforeStart + deltaX;
                        var tg = new TransformGroup();
                        var rad = _activeResizeArea.Rotation * Math.PI / 180;
                        var cx = _activeResizeArea.CalculateCenterPoint().X - _activeRotateAreaCenterPointBeforeStart.X;
                        var cy = _activeResizeArea.CalculateCenterPoint().Y - _activeRotateAreaCenterPointBeforeStart.Y;
                        var tx = cx * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d + cy * Math.Sin(rad);
                        var ty = cx * Math.Sin(rad) - cy * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d;
                        var t = new TranslateTransform(-tx, ty);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
				case SelectionArea.ResizeSide.BOTTOM:
                    {
                        _activeResizeArea.AreaHeight = _activeResizeAreaHeightbeforeStart + deltaY;
                        var tg = new TransformGroup();
                        var rad = _activeResizeArea.Rotation * Math.PI / 180;
                        var cx = _activeResizeArea.CalculateCenterPoint().X - _activeRotateAreaCenterPointBeforeStart.X;
                        var cy = _activeResizeArea.CalculateCenterPoint().Y - _activeRotateAreaCenterPointBeforeStart.Y;
                        var tx = cy * Math.Sin(rad) + cx * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d;
                        var ty = cy * Math.Sin(rad / 2d) * Math.Sin(rad / 2d) * 2d - cx * Math.Sin(rad);
                        var t = new TranslateTransform(-tx, -ty);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
			}
