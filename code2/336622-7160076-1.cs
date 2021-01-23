    public class DataSetParameterInspector : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Type t =returnValue.GetType();
            if (t.IsSubclassOf(typeof(GlobalUtils.RR.Response)))
            {
                foreach (var pi in t.GetProperties())
                {
                    if (pi.PropertyType.IsSubclassOf(typeof(System.Data.DataSet)))
                    {
                        object parameter = pi.GetValue(returnValue, null);
                        if (parameter != null)
                            ((System.Data.DataSet)parameter).SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
                    }
                }
            }
        }
