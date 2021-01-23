    public static T? GetA<T>(this ModelBindingContext bindingContext, string key) where T : struct
            {
                T? valueResult = null;
                if (String.IsNullOrEmpty(key)) return null;
                //Try it with the prefix...
                try
                {
                    valueResult = (T?)bindingContext.ValueProvider.GetValue(bindingContext.ModelName + "." + key).ConvertTo(typeof (T));
                } catch (NullReferenceException){}
                //Didn't work? Try without the prefix if needed...
                if (valueResult == null && bindingContext.FallbackToEmptyPrefix == true)
                {
                    try
                    {
                        valueResult = (T?) bindingContext.ValueProvider.GetValue(key).ConvertTo(typeof (T));
                    } catch (NullReferenceException){}
                }
                return valueResult;
            }
        }
