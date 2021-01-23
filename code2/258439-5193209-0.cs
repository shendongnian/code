    private void ConvertNumber(string value)
    {
        Int64 number; // receives the converted numeric value, if conversion succeeds
        bool result = Int64.TryParse(value, out number);
        if (result)
        {
             // The return value was True, so the conversion was successful
             Console.WriteLine("Converted '{0}' to {1}.", value, number);
        }
        else
        {
            // Make sure the string object is not null, for display purposes
            if (value == null)
            {
                value = String.Empty;
            }
    
             // The return value was False, so the conversion failed
            Console.WriteLine("Attempted conversion of '{0}' failed.", value);
        }
    }
