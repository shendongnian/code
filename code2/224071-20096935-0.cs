          public class StackedColumnSeriesEx : StackedColumnSeries
        {
            protected override DataPoint CreateDataPoint()
            {
            // Custom data point with new fields.
                return new CustomDataPoint();
            }
    
            protected override void UpdateDataItemPlacement(IEnumerable<DataItem> dataItems)
                {
                // Calculate sum here.
                    foreach (var group in this.IndependentValueGroups)
                    {
             
                        decimal sum = 0;
             
                 
            
                   foreach (var dataItem in group.DataItems)
                            {
                                double currentValue = 0;
                                if (ValueHelper.TryConvert(dataItem.ActualDependentValue, out currentValue))
                                {
                                    sum += Convert.ToDecimal(currentValue);
                                }
                            }
                
                            // Set sum and find most top point
                            foreach (DataItem dataItem in group.DataItems)
                            {
                                int index = group.DataItems.IndexOf(dataItem);
                
                                var convertedDataItem = dataItem.DataPoint as CustomDataPoint;
                                if (convertedDataItem == null)
                                {
                                    continue;
                                }
                
                                convertedDataItem.SeriesDefinition = dataItem.SeriesDefinition;
                                convertedDataItem.IsTopPoint = index + 1 == group.DataItems.Count();
                                convertedDataItem.DependentValueSum = sum;
                            }
                        }
       
    
             
                            base.UpdateDataItemPlacement(dataItems);
                        }
                    }
    
