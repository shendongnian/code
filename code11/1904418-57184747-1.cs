    static bool IsValidType (string data_type, string value) {
      switch (data_type) {
        case "System.Int32": return int.TryParse (value, out _);
        case "System.Int64": return long.TryParse (value, out _);
        case "System.Double": return double.TryParse (value, out _);
        case "System.String": return true;
        default: return false;
      }
    }
