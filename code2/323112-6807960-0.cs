    static IEnumerable<T> Get<T>(T value) where T : struct {
        Type underlyingType = Enum.GetUnderlyingType(typeof(T));
        var compareToMethod = underlyingType.GetMethod(
                                  "CompareTo",
                                  new[] { underlyingType }
                              );
        var values = Enum.GetValues(typeof(T));
        for (int index = 0; index < values.Length; index++) {
            int comparison = (int)compareToMethod.Invoke(
                Convert.ChangeType(value, underlyingType),
                new object[] { values.GetValue(index) }
            );
            if (comparison >= 0) {
                yield return (T)values.GetValue(index);
            }
         }
     }
