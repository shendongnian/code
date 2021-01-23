    static void Main(string[] args)
    {
        object number = "1";
        bool hasConverted;
        var convertedValue = DoConvert<int>(number, out hasConverted);
        Console.WriteLine(hasConverted);
        Console.WriteLine(convertedValue);
    }
    public static TConvertType DoConvert<TConvertType>(object convertValue, out bool hasConverted)
    {
        hasConverted = false;
        var converted = default(TConvertType);
        try
        {
            converted = (TConvertType) 
                Convert.ChangeType(convertValue, typeof(TConvertType));
            hasConverted = true;
        }
        catch (InvalidCastException)
        {
        }
        catch (ArgumentNullException)
        {
        }
        catch (FormatException)
        {
        }
        catch (OverflowException)
        {
        }
        return converted;
    }
