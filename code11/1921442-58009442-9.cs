            switch (_activeResizeAreaSide)
            {
                case SelectionArea.ResizeSide.LEFT:
                    {
                        _activeResizeArea.OffsetX = _activeResizeAreaXbeforeStart + deltaX;
                        _activeResizeArea.AreaWidth = _activeResizeAreaWidthbeforeStart - deltaX;
                        var ir = new RotateTransform(_activeResizeArea.Rotation, _activeRotateAreaCenterPointBeforeStart.X, _activeRotateAreaCenterPointBeforeStart.Y);
                        var fr = new RotateTransform(_activeResizeArea.Rotation, _activeResizeArea.CalculateCenterPoint().X, _activeResizeArea.CalculateCenterPoint().Y);
                        var ip = ir.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        var fp = fr.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        var tg = new TransformGroup();
                        var txx = ip.X - fp.X;
                        var tyy = ip.Y - fp.Y;
                        var t = new TranslateTransform(txx, tyy);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
                case SelectionArea.ResizeSide.TOP:
                    {
                        _activeResizeArea.OffsetY = _activeResizeAreaYbeforeStart + deltaY;
                        _activeResizeArea.AreaHeight = _activeResizeAreaHeightbeforeStart - deltaY;
                        var ir = new RotateTransform(_activeResizeArea.Rotation, _activeRotateAreaCenterPointBeforeStart.X, _activeRotateAreaCenterPointBeforeStart.Y);
                        var fr = new RotateTransform(_activeResizeArea.Rotation, _activeResizeArea.CalculateCenterPoint().X, _activeResizeArea.CalculateCenterPoint().Y);
                        var ip = ir.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        var fp = fr.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        var tg = new TransformGroup();
                        var txx = ip.X - fp.X;
                        var tyy = ip.Y - fp.Y;
                        var t = new TranslateTransform(txx, tyy);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
                case SelectionArea.ResizeSide.RIGHT:
                    {
                        _activeResizeArea.AreaWidth = _activeResizeAreaWidthbeforeStart + deltaX;
                        var ir = new RotateTransform(_activeResizeArea.Rotation, _activeRotateAreaCenterPointBeforeStart.X, _activeRotateAreaCenterPointBeforeStart.Y);
                        var fr = new RotateTransform(_activeResizeArea.Rotation, _activeResizeArea.CalculateCenterPoint().X, _activeResizeArea.CalculateCenterPoint().Y);
                        var ip = ir.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        var fp = fr.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        
                        var tg = new TransformGroup();
                        
                        var txx = ip.X - fp.X;
                        var tyy = ip.Y - fp.Y;
                        var t = new TranslateTransform(txx, tyy);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
				case SelectionArea.ResizeSide.BOTTOM:
                    {
                        _activeResizeArea.AreaHeight = _activeResizeAreaHeightbeforeStart + deltaY;
                        var ir = new RotateTransform(_activeResizeArea.Rotation, _activeRotateAreaCenterPointBeforeStart.X, _activeRotateAreaCenterPointBeforeStart.Y);
                        var fr = new RotateTransform(_activeResizeArea.Rotation, _activeResizeArea.CalculateCenterPoint().X, _activeResizeArea.CalculateCenterPoint().Y);
                        var ip = ir.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        var fp = fr.Transform(new Point(_activeResizeArea.OffsetX, _activeResizeArea.OffsetY));
                        var tg = new TransformGroup();
                        var txx = ip.X - fp.X;
                        var tyy = ip.Y - fp.Y;
                        var t = new TranslateTransform(txx, tyy);
                        tg.Children.Add(_activeResizeArea.RotateTransform);
                        tg.Children.Add(t);
                        _activeResizeArea.AreaCanvas.RenderTransform = tg;
                    }
                    break;
			}
