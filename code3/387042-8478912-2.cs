    if (typeof(Money).IsAssignableFrom(typeof(T))
    {
        // special handling required to convert decimal to money
        castedValue = new Money() { Value = value };  // ? best guess
    }
    else
    {
        castedValue =(T)value;
    }
