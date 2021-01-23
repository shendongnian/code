    public static class ObjectHelper
    {
        public static T Cast<T>(this Object source)
        {
            var destination = (T)Activator.CreateInstance(typeof(T));
            var sourcetype = source.GetType();
            var destinationtype = destination.GetType();
            var sourceProperties = sourcetype.GetProperties();
            var destionationProperties = destinationtype.GetProperties();
            var commonproperties = from sp in sourceProperties
                                   join dp in destionationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };
            foreach (var match in commonproperties)
            {
                match.dp.SetValue(destination, match.sp.GetValue(source, null), null);
            }
            return destination;
        }
    }
