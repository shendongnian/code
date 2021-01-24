    class MyCompositeAnnotation : CompositeAnnotation
    {
        
        public MyCompositeAnnotation()
        {
            Loaded+=OnLoaded;
            
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //BoxAnnotation
            Annotations.Add(new BoxAnnotation
            {
                CoordinateMode = AnnotationCoordinateMode.Relative,
                IsEditable = false,
                ResizeDirections = SciChart.Charting.XyDirection.XDirection,
                Background = grayBrushLight,
                BorderBrush = grayBrushRegular,
                X1 = 0,
                X2 = 1,
                Y1 = 0,
                Y2 = 1
            });
            //Center dashed line
            Annotations.Add(new LineAnnotation
            {
                CoordinateMode = AnnotationCoordinateMode.Relative,
                Stroke = grayBrushRegular,
                StrokeThickness = 1,
                IsEditable = true,
                ResizeDirections = SciChart.Charting.XyDirection.XDirection,
                StrokeDashArray = new DoubleCollection(new double[] { 2, 4 }),
                X1 = 0,
                X2 = 1,
                Y1 = 0.5,
                Y2 = 0.5
            });
            Loaded -= OnLoaded;
        }
    }
