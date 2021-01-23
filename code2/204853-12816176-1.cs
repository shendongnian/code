    // n.b. cell is derived from a WorkSheet object xlSheet
    // by cell = xlSheet.Cells[row, col]
    public T Cell2Class<T>(object cell)
    {
        T result = default(T);
        try
        {
            Range rg = (Range)cell;
            object value = rg.Value2;
            if (value != null)
            {
                if (typeof(T) == typeof(DateTime))
                {
                    DateTime dateValue;
                    if (value is double)
                    {
                        dateValue = DateTime.FromOADate((double)value);
                    }
                    else
                    {
                        DateTime.TryParse((string)value, out dateValue);
                    }
                    result = (T)Convert.ChangeType(dateValue, typeof(T));
                }
                else
                    result = (T)Convert.ChangeType(value, typeof(T));
            }
        }
        catch
        {
            result = default(T);
        }
        return result;
    }
