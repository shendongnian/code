    using ImpromptuInterface;
    ...
    public MyData CreateMyData(double? value1, double? value2, double? value3)
    {
        var arg = InvokeArg.Create;
        var argList = new List<Object>();
        if(value1.HasValue)
            argList.Add(arg("value1",value1));
        if(value2.HasValue)
            argList.Add(arg("value2",value2));
        if(value3.HasValue)
            argList.Add(arg("value3",value3));
        return Impromptu.InvokeConstructor(typeof(MyData), argList.ToArray());
    }
