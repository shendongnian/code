    if (typeof(T).IsAssignableFrom(typeof(Money))
    {
        // special handling required to convert decimal to money
        castedValue = new Money() { Value = value };  // ? best guess
    }
    else
    {
        castedValue =(T)value;
    }
