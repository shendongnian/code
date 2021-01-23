    // Same check for nullable DateTime.
    else if (p.PropertyType == typeof(Nullable<DateTime>)) {
        DateTime? date = (DateTime?)p.GetValue(obj, null);
        if (date.HasValue) {
            DateTime? newDate = DateTime.SpecifyKind(date.Value, DateTimeKind.Utc);
            p.SetValue(obj, null, null);
            p.SetValue(obj, newDate, null);
        }
    }
