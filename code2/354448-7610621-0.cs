    Temperature cool = new Temperature(5);
    Type[] targetTypes = { typeof(SByte), typeof(Int16), typeof(Int32),
                            typeof(Int64), typeof(Byte), typeof(UInt16),
                            typeof(UInt32), typeof(UInt64), typeof(Decimal),
                            typeof(Single), typeof(Double), typeof(String) };
    CultureInfo provider = new CultureInfo("fr-FR");
    foreach (Type targetType in targetTypes)
    {
        try {
        object value = Convert.ChangeType(cool, targetType, provider);
        Console.WriteLine("Converted {0} {1} to {2} {3}.",
                            cool.GetType().Name, cool.ToString(),
                            targetType.Name, value);
        }
        catch (InvalidCastException) {
        Console.WriteLine("Unsupported {0} --> {1} conversion.",
                            cool.GetType().Name, targetType.Name);
        }                     
        catch (OverflowException) {
        Console.WriteLine("{0} is out of range of the {1} type.",
                            cool, targetType.Name);
        }
    }
