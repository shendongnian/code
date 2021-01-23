      private void SeriesLoaded(object sender, RoutedEventArgs e)
        {
            var series = (Series) sender;
            ColorDataPointSeries(series);
        }
        /// <summary>
        /// Colors in <see cref="DataPoint"/> from the bound DataSource for the pie chart layer control.
        /// </summary>
        /// <param name="series"></param>
        private static void ColorDataPointSeries(Series series)
        {
            //If nothing is bound there is nothing to do.
            if (null == series.DataSource)
                return;
            var dataSource = ((IEnumerable<GeographyDataDetailItem>) series.DataSource).ToList();
            var dataPoints = series.DataPoints;
            //Note, I am depending on the control to have the exact number of dataPoints as dataSource elements here.
            for (var sourceIndex = 0; sourceIndex < dataSource.Count(); sourceIndex++)
            {
                //Iterate through each dataSoruce, looking for a color provider.
                //If one exists, change the Fill property of the control DataPoint.
                var colorProvider = dataSource[sourceIndex].ColorProvider;
                if (null != colorProvider)
                    dataPoints[sourceIndex].Fill = new SolidColorBrush(colorProvider.BackgroundColor);
            }
        }            
