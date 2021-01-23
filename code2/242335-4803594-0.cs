    public static class Extension
        {
            public static object Execute(this object instance, string path)
            {
                string[] cmd = path.Split('.');
                string subString = cmd[0];
                object returnValue = null;
                Type t = instance.GetType();
                if (subString.Contains("("))
                {
                    string[] paramString = subString.Split('(');
                    string[] parameters = paramString[1].Replace(")", "").Split(',');
                    MethodInfo info = t.GetMethod(paramString[0]);
                    ParameterInfo[] pInfo = info.GetParameters();
                    List<object> paramList = new List<object>();
                    for (int i = 0; i < pInfo.Length; i++)
                    {
                        ParameterInfo pram = pInfo[i];
                        Type pType = pram.ParameterType;
                        object obj = Convert.ChangeType(parameters[i], pType);
                        paramList.Add(obj);
                    }
                    if (info == null) returnValue = null;
                    else
                        returnValue = info.Invoke(instance, paramList.ToArray());
                }
                else
                {
    
                    PropertyInfo pi = t.GetProperty(subString);
                    if (pi == null) returnValue = null;
                    else
                        returnValue = pi.GetValue(instance, null);
                }
                if (returnValue == null || cmd.Length == 1)
                    return returnValue;
                else
                {
                    returnValue = returnValue.Execute(path.Replace(cmd[0] + ".", ""));
                }
                return returnValue;
            }
    
    
        }
