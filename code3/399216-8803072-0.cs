    public static T? TryParse<T> (this string text) where T: struct
    {
        T? result = null;
        if (!string.IsNullOrEmpty(text))
        {
            try
            {
                result = (T?) Convert.ChangeType(text, typeof (T));
            }
            catch (InvalidCastException) {}
            catch (FormatException) {}
            catch (OverflowException) {}
        }
        return result;
    }
