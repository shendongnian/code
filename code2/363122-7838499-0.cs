    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action) {
      foreach (var cur in enumerable) {
        action(cur);
      }
    }
    
    ...
    newlist
      .Where(c => c.StatusID == EmergencyCV.ID)
      .ForEach(cur => cur.color = "Red);
