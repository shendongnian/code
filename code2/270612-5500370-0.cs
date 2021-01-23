    public static Dictionary<int, string> ToDictionary(this Enum @enum)
    {
      var type = @enum.GetType();
      return Enum.GetValues(type).Cast<object>().ToDictionary(e => (int)e, e => Enum.GetName(type, e));
    }
