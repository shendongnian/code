    public static IDictionary<String, Int32> ConvertEnumToDictionary<K>()
    {
     if (typeof(K).BaseType != typeof(Enum))
     {
       throw new InvalidCastException();
     }
    
     return Enum.GetValues(typeof(K)).Cast<Int32>().ToDictionary(currentItem => Enum.GetName(typeof(K), currentItem));
    }
