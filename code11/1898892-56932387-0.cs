    Enum result;
    if (this._isEnum1)
    {
        Enum.TryParse("value", out _Enum1 x);
        result = x;
    }
    else
    {
        Enum.TryParse("TextArea", out _Enum2 x);
        result = x;
    }
    
    Console.WriteLine(result);
