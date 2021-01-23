    public class DelayHelper : IMultiValueConverter
    {
        #region IMultiValueConverter Members
        public object Convert(
             object[] values,
             Type targetType,
             object parameter,
             System.Globalization.CultureInfo culture)
        {
            var sourceElement = values[1] as FrameworkElement;
            var dp = values[2] as DependencyProperty;
            var paramArray = parameter as ArrayList;
            var existingValue
                    = paramArray != null && paramArray.Count == 2
                          ? paramArray[1] : sourceElement.GetValue(dp);
            var newValue = values[0];
            var bndExp = BindingOperations.GetMultiBindingExpression(sourceElement, dp);
            var temp = new DispatcherTimer() { IsEnabled = false };
            var dspTimer
                = new DispatcherTimer(
                    new TimeSpan(0,0,0,0, int.Parse(paramArray[0].ToString())),
                    DispatcherPriority.Background,
                    new EventHandler(
                        delegate
                        {
                            if (bndExp != null && existingValue != newValue)
                            {
                                var array
                                     = bndExp.ParentMultiBinding.ConverterParameter
                                         as ArrayList;
                                var existingInterval = array[0];
                                array.Clear();
                                array.Add(existingInterval);
                                array.Add(newValue);
                                bndExp.UpdateTarget();
                            }
                            temp.Stop();
                        }),
                    sourceElement.Dispatcher);
            temp = dspTimer;
            dspTimer.Start();
            return existingValue;
        }
        public object[] ConvertBack(
             object value,
             Type[] targetTypes,
             object parameter,
             System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
