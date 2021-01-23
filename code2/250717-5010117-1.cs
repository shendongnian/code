    dynamic _DynInteger = new ExpandoObject();
    _DynInteger.Integer = 10;
    ((INotifyPropertyChanged)_DynInteger).PropertyChanged += (o, e) =>
    {
        Console.WriteLine("Property {0} changed", e.PropertyName);
    };
    Console.WriteLine("value: {0}", _DynInteger.Integer );
    _DynInteger.Integer = 20;
     Console.WriteLine("value: {0}", _DynInteger.Integer);
