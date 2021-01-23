    public class ArgumentConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object convertedValue = null;
            if(value != null)
            {
                var argumentModelItem = value as ModelItem;
                if(argumentModelItem != null)
                {
                    ModelProperty argumentModelProperty = argumentModelItem.Properties["Expression"];
                    
                    if(argumentModelProperty != null && argumentModelProperty.Value != null)
                    {
                        var computedValue = argumentModelProperty.ComputedValue;
                        var activity = (Activity) computedValue;
                        convertedValue = WorkflowInvoker.Invoke(activity)["Result"];
                    }
                }
            }
            return convertedValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // here targetType should be InArgument<T>
            // assume a single generic argument
            Type arg0 = targetType.GetGenericArguments()[0];
            ConstructorInfo argConstructor = targetType.GetConstructor(new[] {arg0});
            var argument = argConstructor.Invoke(new[] { value });
            return argument;
        }
        #endregion
    }
