    double foundangle = 0;
            //verify an actual transform group is there before getting rotate angle
            if (RotatingCanvas.RenderTransform.Value.ToString() != "Identity")
            {
                RotateTransform rt = (RotatingCanvas.RenderTransform as TransformGroup).Children[2] as RotateTransform;
                foundangle = rt.Angle;
            }
            RotateTransform rottrans = new RotateTransform(foundangle*-1);
            RotatingEl.RenderTransform = rottrans;
            GeneralTransform generalTransformStaticEl = StaticEl.TransformToVisual(RotatingCanvas);
			Point pointstatic = generalTransformStaticEl.Transform(new Point());
            DoubleAnimation ELMoveY = new DoubleAnimation();
            ELMoveY.From = Canvas.GetTop(RotatingEl);
            ELMoveY.To = pointstatic.Y;
            ELMoveY.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            DoubleAnimation ELMoveX = new DoubleAnimation();
            ELMoveX.From = Canvas.GetLeft(RotatingEl);
            ELMoveX.To = pointstatic.X;
            ELMoveX.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            RotatingEl.BeginAnimation(Canvas.LeftProperty, ELMoveX);
            RotatingEl.BeginAnimation(Canvas.TopProperty, ELMoveY);
