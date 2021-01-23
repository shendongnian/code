    using System.Linq;
    // ...
    while (reader.Read())
    {
        Object[] values = new Object[reader.FieldCount];
        int fieldCount = reader.GetValues(values);
        values.ToList().ForEach(value => results.Add(parseInt(value));
    }
