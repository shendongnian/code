    // The function is an extension method, so it must be defined in a static class.
    public static class ResampleExt
    {
        // Resample an input time series and create a new time series between two 
        // particular dates sampled at a specified time interval.
        public static IEnumerable<OutputDataT> Resample<InputValueT, OutputDataT>(
    
            // Input time series to be resampled.
            this IEnumerable<InputValueT> source,
    
            // Start date of the new time series.
            DateTime startDate,
    
            // Date at which the new time series will have ended.
            DateTime endDate,
    
            // The time interval between samples.
            TimeSpan resampleInterval,
    
            // Function that selects a date/time value from an input data point.
            Func<InputValueT, DateTime> dateSelector,
    
            // Interpolation function that produces a new interpolated data point
            // at a particular time between two input data points.
            Func<DateTime, InputValueT, InputValueT, double, OutputDataT> interpolator
        )
        {
            // ... argument checking omitted ...
    
            //
            // Manually enumerate the input time series...
            // This is manual because the first data point must be treated specially.
            //
            var e = source.GetEnumerator();
            if (e.MoveNext())
            {
                // Initialize working date to the start date, this variable will be used to 
                // walk forward in time towards the end date.
                var workingDate = startDate;
    
                // Extract the first data point from the input time series.
                var firstDataPoint = e.Current;
                
                // Extract the first data point's date using the date selector.
                var firstDate = dateSelector(firstDataPoint);
    
                // Loop forward in time until we reach either the date of the first
                // data point or the end date, which ever comes first.
                while (workingDate < endDate && workingDate <= firstDate)
                {
                    // Until we reach the date of the first data point,
                    // use the interpolation function to generate an output
                    // data point from the first data point.
                    yield return interpolator(workingDate, firstDataPoint, firstDataPoint, 0);
    
                    // Walk forward in time by the specified time period.
                    workingDate += resampleInterval; 
                }
    
                //
                // Setup current data point... we will now loop over input data points and 
                // interpolate between the current and next data points.
                //
                var curDataPoint = firstDataPoint;
                var curDate = firstDate;
    
                //
                // After we have reached the first data point, loop over remaining input data points until
                // either the input data points have been exhausted or we have reached the end date.
                //
                while (workingDate < endDate && e.MoveNext())
                {
                    // Extract the next data point from the input time series.
                    var nextDataPoint = e.Current;
    
                    // Extract the next data point's date using the data selector.
                    var nextDate = dateSelector(nextDataPoint);
                    
                    // Calculate the time span between the dates of the current and next data points.
                    var timeSpan = nextDate - firstDate;
    
                    // Loop forward in time until wwe have moved beyond the date of the next data point.
                    while (workingDate <= endDate && workingDate < nextDate)
                    {
                        // The time span from the current date to the working date.
                        var curTimeSpan = workingDate - curDate; 
    
                        // The time between the dates as a percentage (a 0-1 value).
                        var timePct = curTimeSpan.TotalSeconds / timeSpan.TotalSeconds; 
    
                        // Interpolate an output data point at the particular time between 
                        // the current and next data points.
                        yield return interpolator(workingDate, curDataPoint, nextDataPoint, timePct);
    
                        // Walk forward in time by the specified time period.
                        workingDate += resampleInterval; 
                    }
    
                    // Swap the next data point into the current data point so we can move on and continue
                    // the interpolation with each subsqeuent data point assuming the role of 
                    // 'next data point' in the next iteration of this loop.
                    curDataPoint = nextDataPoint;
                    curDate = nextDate;
                }
    
                // Finally loop forward in time until we reach the end date.
                while (workingDate < endDate)
                {
                    // Interpolate an output data point generated from the last data point.
                    yield return interpolator(workingDate, curDataPoint, curDataPoint, 1);
    
                    // Walk forward in time by the specified time period.
                    workingDate += resampleInterval; 
                }
            }
        }
    }
