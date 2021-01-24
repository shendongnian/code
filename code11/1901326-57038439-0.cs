    var alwaysReturnTrueMethodInfo = typeof(YourClass).GetMethod("AlwaysReturnTrue").MakeGenericMethod(someVariableType);
    Delegate validateFunc;
    if (validateOfType == null)
    {
        validateFunc = Delegate.CreateDelegate(validateFuncType, alwaysReturnTrueMethodInfo);
    }
    else
    {
        validateFunc = Delegate.CreateDelegate(validateFuncType, validateOfType);
    }
