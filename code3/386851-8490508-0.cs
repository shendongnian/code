        public static DateTime? GetValueNDateTime(ModelBindingContext context, string searchPrefix, string key, string format)
        {
            ValueProviderResult vpr = context.ValueProvider.GetValue(searchPrefix + key);
            DateTime outVal;
            if (DateTime.TryParseExact(vpr.AttemptedValue, format, null, System.Globalization.DateTimeStyles.None, out outVal))
            {
                return outVal;
            }
            else
            {
                return null;
            }
        }
