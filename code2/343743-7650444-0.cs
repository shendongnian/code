    using System;
    using System.Linq;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    public class CustomQueryStringConverter : QueryStringConverter
    {
        public override bool CanConvert(Type type)
        {
            return base.CanConvert(type.IsArray ? type.GetElementType() : type);
        }
        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            object result = null;
            if (parameterType.IsArray)
            {
                if (!ReferenceEquals(parameter, null))
                {
                    object[] items = parameter
                        .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .Select(s => base.ConvertStringToValue(s.Trim(), parameterType.GetElementType()))
                        .ToArray();
                    Array arrayResult = Array.CreateInstance(parameterType.GetElementType(), items.Length);
                    for (int i = 0; i < items.Length; ++i)
                    {
                        arrayResult.SetValue(items[i], i);
                    }
                    result = arrayResult;
                }
            }
            else
            {
                result = base.ConvertStringToValue(parameter, parameterType);
            }
            return result;
        }
        public override string ConvertValueToString(object parameter, Type parameterType)
        {
            string result = string.Empty;
            if (parameterType.IsArray)
            {
                foreach (object item in (Array)parameter)
                {
                    result += item.ToString() + ",";
                }
                result = result.TrimEnd(',');
            }
            else
            {
                result = base.ConvertValueToString(parameter, parameterType);
            }
            return result;
        }
        public class CustomQueryStringBehavior : WebHttpBehavior
        {
            protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
            {
                return new CustomQueryStringConverter();
            }
        }
    }
