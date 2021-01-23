    // TODO: Boil down to two with Generics if possible
    #region AutoMapTypeConverters
    // Automap type converter definitions for 
    // int, int?, decimal, decimal?, bool, bool?, Int64, Int64?, DateTime
    // Automapper string to int?
    private class NullIntTypeConverter : TypeConverter<string, int?>
    {   protected override int? ConvertCore(string source)
        {   if (source == null)
                return null;
            else
            {   int result;
                return Int32.TryParse(source, out result) ? (int?) result : null;
    }   }   }
    // Automapper string to int
    private class IntTypeConverter : TypeConverter<string, int>
    {   protected override int ConvertCore(string source)
        {   if (source == null)
                throw new MappingException("null string value cannot convert to non-nullable return type.");
            else
                return Int32.Parse(source); 
    }   }
    // Automapper string to decimal?
    private class NullDecimalTypeConverter : TypeConverter<string, decimal?>
    {   protected override decimal? ConvertCore(string source)
        {   if (source == null)
                return null;
            else
            {   decimal result;
                return Decimal.TryParse(source, out result) ? (decimal?) result : null;
    }   }   }
    // Automapper string to decimal
    private class DecimalTypeConverter : TypeConverter<string, decimal>
    {   protected override decimal ConvertCore(string source)
        {   if (source == null)
                throw new MappingException("null string value cannot convert to non-nullable return type.");
            else
                return Decimal.Parse(source); 
    }   }
    // Automapper string to bool?
    private class NullBooleanTypeConverter : TypeConverter<string, bool?>
    {   protected override bool? ConvertCore(string source)
        {   if (source == null)
                return null;
            else
            {   bool result;
                return Boolean.TryParse(source, out result) ? (bool?) result : null;
    }   }   }
    // Automapper string to bool
    private class BooleanTypeConverter : TypeConverter<string, bool>
    {   protected override bool ConvertCore(string source)
        {   if (source == null)
                throw new MappingException("null string value cannot convert to non-nullable return type.");
            else
                return Boolean.Parse(source); 
    }   }
    // Automapper string to Int64?
    private class NullInt64TypeConverter : TypeConverter<string, Int64?>
    {   protected override Int64? ConvertCore(string source)
        {   if (source == null)
                return null;
            else
            {   Int64 result;
                return Int64.TryParse(source, out result) ? (Int64?)result : null;
    }   }   }
    // Automapper string to Int64
    private class Int64TypeConverter : TypeConverter<string, Int64>
    {   protected override Int64 ConvertCore(string source)
        {   if (source == null)
                throw new MappingException("null string value cannot convert to non-nullable return type.");
            else
                return Int64.Parse(source); 
    }   }
    // Automapper string to DateTime?
    // In our case, the datetime will be a JSON2.org datetime
    // Example: "/Date(1288296203190)/"
    private class NullDateTimeTypeConverter : TypeConverter<string, DateTime?>
    {   protected override DateTime? ConvertCore(string source)
        {   if (source == null)
                return null;
            else
            {   DateTime result;
                return DateTime.TryParse(source, out result) ? (DateTime?) result : null;
    }   }   }
    // Automapper string to DateTime
    private class DateTimeTypeConverter : TypeConverter<string, DateTime>
    {   protected override DateTime ConvertCore(string source)
        {   if (source == null)
                throw new MappingException("null string value cannot convert to non-nullable return type.");
            else
                return DateTime.Parse(source); 
    }   }
    #endregion
