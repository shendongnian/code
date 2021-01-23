    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    
    namespace Something
    {
        public class FlagsToBoolConverter : MarkupExtension, IValueConverter
        {
            private FlagsToBoolConverter _converter;
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                _converter = new FlagsToBoolConverter();
                return _converter;
            }
    
            private ulong _sourceValue;
    
            public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    var type = value.GetType();
                    if (type.IsEnum)
                    {
                        ulong mask = (ulong)System.Convert.ChangeType(Enum.Parse(type, (string)parameter), typeof(ulong));
                        _sourceValue = (ulong)System.Convert.ChangeType(Enum.Parse(type, value.ToString()), typeof(ulong));
                        return ((mask & _sourceValue) != 0);
                    }
                    return value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FlagsEnumValueConverter: Invalid Cast(to) Value={0} Type={1} Param={2} Exception{3}", value, targetType, parameter, ex);
                }
                return value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    if (targetType.IsEnum)
                    {
                        var original = this._sourceValue;
                        var originalEnum = Enum.Parse(targetType, original.ToString());
                        var maskEnum = Enum.Parse(targetType, (string)parameter);
                        var mask = (ulong)System.Convert.ChangeType(maskEnum, typeof(ulong));
                        _sourceValue ^= mask;
                        var sourceEnum = Enum.Parse(targetType, _sourceValue.ToString());
                        Console.WriteLine($"Modified Value: {original} ({originalEnum}) by Mask {mask} ({maskEnum}) Result = {_sourceValue} ({sourceEnum})");
                        return sourceEnum;
                    }
                    return value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FlagsEnumValueConverter: Invalid Cast(from) Value={0} Type={1} Param={2} Exception{3}", value, targetType, parameter, ex);
                }
                return value;
            }
        }
    }
    
