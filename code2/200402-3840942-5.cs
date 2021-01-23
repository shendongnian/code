    public static T Sum<T>(this DataTable dt, string columnName) {
      var sum = dt.Compute("Sum(" + columnName + ")", "");
      if (sum == DBNull.Value) return default(T);
      return (T)sum;
    }
