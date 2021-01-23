        ParameterInfo param = paramList[i]; 
        Type type = paramArray[i].GetType();
        bool valid = false;
        if (info.ParameterType.IsInterface)
            valid = type.GetInterfaces().Contains(param.ParameterType);
        else
            valid = type.IsSubclassOf(param.ParameterType);
