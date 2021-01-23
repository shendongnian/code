    public static void ConvertDatesToUtc(this object obj) {
                foreach (var prop in obj.GetType().GetProperties().Where(p => p.CanWrite)) {
                    var t = prop.PropertyType;
                    if (t == typeof(DateTime)) {
                        //found datetime, specify its kind as utc.
                        var oldValue = (DateTime)prop.GetValue(obj, null);
                        var newValue = DateTime.SpecifyKind(oldValue, DateTimeKind.Utc);
                        prop.SetValue(obj, newValue, null);
                    } else if (t == typeof(DateTime?)) {
                        //found nullable datetime, if populated specify its kind as utc.
                        var oldValue = (DateTime?)prop.GetValue(obj, null);
                        if (oldValue.HasValue) {
                            var newValue = (DateTime)DateTime.SpecifyKind(oldValue.Value, DateTimeKind.Utc);
                            prop.SetValue(obj, newValue, null);
                        }
                    } else if (typeof(IEnumerable).IsAssignableFrom(t)) {
                        //traverse child lists recursively.
                        var vals = prop.GetValue(obj, null);
                        if (vals != null) {
                            foreach (object o in (IEnumerable)vals) {
                                ConvertDatesToUtc(o);
                            }
                        }
                    } else {
                        //traverse child objects recursively.
                        var val = prop.GetValue(obj, null);
                        if (val != null)
                            ConvertDatesToUtc(val);
                    }
                }
            }
