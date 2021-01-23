    [Guid("xxx")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Vector
    {        
        [ComVisible(false)]
        public IList<double> Values { get; set; }
        public object[,] GetExcelValues()
        {
            // own extension method
            return Values.ConvertToExcelColumn();
        }
        public void SetExcelValues(object comArray)
        {
            IEnumerable<object> values = ConvertExcelCloumnToEnumerable(comArray);
            Values = new List<double>(values.Select(Convert.ToDouble));
        }
        private static IEnumerable<object> ConvertExcelCloumnToEnumerable(object comObject)
        {
            Type comObjectType = comObject.GetType();
            if (comObjectType != typeof(object[,]))
                return new object[0];
            int count = (int)comObjectType.InvokeMember("Length", BindingFlags.GetProperty, null, comObject, null);
            var result = new List<object>(count);
            var indexArgs = new object[2];
            for (int i = 1; i <= count; i++)
            {
                indexArgs[0] = i;
                indexArgs[1] = 1;
                object valueAtIndex = comObjectType.InvokeMember("GetValue", BindingFlags.InvokeMethod, null, comObject, indexArgs);
                result.Add(valueAtIndex);
            }
            return result;
        }
    }
