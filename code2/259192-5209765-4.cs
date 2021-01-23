    IList<object> originalResult = (IList<object>)op.Invoke(method);
    List<string> typeSafeResult = new List<string>();
    foreach(object element in originalResult)
    {
        typeSafeResult.Add((string)element);
    }
