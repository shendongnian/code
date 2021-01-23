	public class ArgumentToInt32Converter: IValueConverter {
		object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			object convertedValue = null;
			if (value != null) {
				ModelItem argumentModelItem = value as ModelItem;
				if (argumentModelItem != null && argumentModelItem.Properties["Expression"] != null && argumentModelItem.Properties["Expression"].Value != null) {
					if (argumentModelItem.Properties["Expression"].ComputedValue.GetType() == typeof(Literal <Int32> )) {
						convertedValue = (argumentModelItem.Properties["Expression"].ComputedValue as Literal <Int32> ).Value;
					} else {
						convertedValue = null
					}
				}
			}
			return convertedValue;
		}
		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			// Convert Int32 value to InArgument<Int32>
			Int32 itemContent = (Int32) value;
			VisualBasicValue <Int32> vbArgument = new VisualBasicValue <Int32> (itemContent);
			InArgument <Int32> inArgument = new InArgument <Int32> (vbArgument);
			return inArgument;
		}
	}
