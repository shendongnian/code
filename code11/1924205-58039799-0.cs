    public static class GenericExtensions
    {
    #region ParseTo
        public static TOut ParseTo<TInput, TOut>(this TInput tInput)
        {
            TOut tOut = (TOut)Activator.CreateInstance(typeof(TOut));
            return ParseTo(tInput, tOut);
        }
        public static TOut ParseTo<TInput, TOut>(this TInput tInput, TOut tOut)
        {
            Type type = tInput.GetType();
            PropertyInfo[] properties = tOut.GetType().GetProperties();
            for (int i = 0; i < (int)properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                PropertyInfo property = type.GetProperty(propertyInfo.Name);
                if (property != null)
                {
                    try
                    {
                        propertyInfo.SetValue(tOut, property.GetValue(tInput, null), null);
                    }
                    catch
                    {
                    }
                }
                else if (propertyInfo.Name.Contains("_"))
                {
                    propertyInfo.SetValue(tOut, HelperGetPropValue(propertyInfo.Name, tInput), null);
                }
            }
            return tOut;
        }
        public static List<TOut> ParseTo<TInput, TOut>(this IEnumerable<TInput> list)
        {
            List<TOut> result = new List<TOut>();
            PropertyInfo[] properties = typeof(TOut).GetProperties();
            Dictionary<string, PropertyInfo> strs = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] propertyInfoArray = typeof(TInput).GetProperties();
            for (int i = 0; i < propertyInfoArray.Length; i++)
            {
                PropertyInfo propertyInfo = propertyInfoArray[i];
                strs.Add(propertyInfo.Name, propertyInfo);
            }
            foreach (TInput tInput in list)
            {
                TOut tOut = (TOut)Activator.CreateInstance(typeof(TOut));
                PropertyInfo[] propertyInfoArray1 = properties;
                for (int j = 0; j < propertyInfoArray1.Length; j++)
                {
                    PropertyInfo propertyInfo1 = propertyInfoArray1[j];
                    try
                    {
                        if (strs.ContainsKey(propertyInfo1.Name))
                        {
                            propertyInfo1.SetValue(tOut, strs[propertyInfo1.Name].GetValue(tInput, null), null);
                        }
                        else if (propertyInfo1.Name.Contains("_"))
                        {
                            propertyInfo1.SetValue(tOut, HelperGetPropValue(propertyInfo1.Name, tInput), null);
                        }
                    }
                    catch
                    {
                    }
                }
                result.Add(tOut);
            }
            return result;
        }
        public static object HelperGetPropValue(string name, object obj)
        {
            object value;
            string[] strArrays = name.Split(new char[] { '\u005F' });
            if (obj != null)
            {
                PropertyInfo property = obj.GetType().GetProperty(strArrays[0]);
                if (property != null)
                {
                    object value1 = property.GetValue(obj, null);
                    try
                    {
                        value = value1.GetType().GetProperty(strArrays[1]).GetValue(value1, null);
                    }
                    catch
                    {
                        value = string.Empty;
                    }
                }
                else
                {
                    value = null;
                }
            }
            else
            {
                value = null;
            }
            return value;
        }
        #endregion
	}
