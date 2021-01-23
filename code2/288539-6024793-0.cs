                        series = new LineSeries();
                        Style dataPointStyle = GetNewDataPointStyle();
                        series.DataPointStyle = dataPointStyle;
        /// <summary>
        /// Gets the new data point style.
        /// </summary>
        /// <returns></returns>
        private static Style GetNewDataPointStyle()
        {
            Color background = Color.FromRgb((byte)random.Next(255), 
                                             (byte)random.Next(255), 
                                             (byte)random.Next(255));
            Style style = new Style(typeof(DataPoint));
            Setter st1 = new Setter(DataPoint.BackgroundProperty, 
                                        new SolidColorBrush(background));
            Setter st2 = new Setter(DataPoint.BorderBrushProperty, 
                                        new SolidColorBrush(Colors.White));
            Setter st3 = new Setter(DataPoint.BorderThicknessProperty, new Thickness(0.1));
            Setter st4 = new Setter(DataPoint.TemplateProperty, null);
            style.Setters.Add(st1);
            style.Setters.Add(st2);
            style.Setters.Add(st3);
            style.Setters.Add(st4);
            return style;
        }
