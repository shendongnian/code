    interface IStatusFieldMarker
    {
    }
    static class Extensions
    {
        public static string GetStatusFieldName(this IStatusFieldMarker t) =>
            t.GetType()
            .GetProperties()
            .Single(p => Attribute.IsDefined(p, typeof(StatusFieldAttributeAttribute)))
            .Name;
        // optional getter/setter
        public static int GetStatus(this IStatusFieldMarker t) =>
            (int)(t.GetType()
            .GetProperty(GetStatusFieldName(t))
            .GetValue(t));
        public static void SetStatus(this IStatusFieldMarker t, int value)
        {
            t.GetType()
            .GetProperty(GetStatusFieldName(t))
            .SetValue(t, value);
        }
    }
