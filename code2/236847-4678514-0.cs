    internal static Boolean IsEven(this Int32 @this)
    {
        return @this % 2 == 0;
    }
    
    internal static IDictionary<String, String> ToDictionary(this String[] @this)
    {
        if (!@this.Length.IsEven())
            throw new ArgumentException( "Array doesn't contain an even number of entries" );
    
        var dictionary = new Dictionary<String, String>();
    
        for (var i = 0; i < @this.Length; i += 2)
        {
            var key = @this[i];
            var value = @this[i + 1];
                    
            dictionary.Add(key, value);
        }
    
        return dictionary;
    }
