                char isOkToEmailPromos = GetAChar(reader, 9); // Calling method
    private char GetAChar(SqlDataReader rd, int column)
        {
            char[] value = new char[1];
            long charCount = (long)rd.GetChars(column, 0, value, 0, value.Length); 
            if (charCount != value.Length) throw new InvalidOperationException();
            return value[0];
        }
