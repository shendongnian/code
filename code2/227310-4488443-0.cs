    public void Show(int value)
        {
            ParameterInfo[] info = MethodInfo.GetCurrentMethod().GetParameters();
            Trace.WriteLine(string.Format("{0} {1}={2}", info[0].ParameterType.ToString(), info[0].Name, value.ToString()));
        }
