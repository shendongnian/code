    public static Dictionary<string, int> GetAllNames(this IDataRecord record) {
      var result = new Dictionary<string, int>();
      for (int i = 0; i < record.FieldCount; i++) {
        result.Add(record.GetName(i), i);
      }
      return result;
    }
