            public static object Eval(this object instance, string path)
        {
            string[] cmd = path.Split('.');
            string subString = cmd[0];
            object returnValue = null;
            Type t = instance.GetType();
            if (subString.Contains("("))
            {
                string[] paramString = subString.Split('(');
                string[] parameters = paramString[1].Replace(")", "").Split(new Char[]{','},StringSplitOptions.RemoveEmptyEntries);
                bool hasNoParams = parameters.Length == 0;
                List<Type> typeArray = null;
                if (hasNoParams) typeArray = new List<Type>();
                foreach (string parameter in parameters)
                {
                    if (parameter.Contains(":"))
                    {
                        if (typeArray == null) typeArray = new List<Type>();
                        string[] typeValue = parameter.Split(':');
                        Type paramType = Type.GetType(typeValue[0].Replace('_','.'));
                        
                        typeArray.Add(paramType);
                    }
                }
                MethodInfo info = null;
                if (typeArray == null)
                    info = t.GetMethod(paramString[0]);
                else
                    info = t.GetMethod(paramString[0], typeArray.ToArray());
                ParameterInfo[] pInfo = info.GetParameters();
                List<object> paramList = new List<object>();
                for (int i = 0; i < pInfo.Length; i++)
                {
                    string currentParam = parameters[i];
                    if (currentParam.Contains(":"))
                    {
                        currentParam = currentParam.Split(':')[1];
                    }
                    ParameterInfo pram = pInfo[i];
                    Type pType = pram.ParameterType;
                    object obj = Convert.ChangeType(currentParam, pType);
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
                returnValue = returnValue.Eval(path.Replace(cmd[0] + ".", ""));
            }
            return returnValue;
        }
