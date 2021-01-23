    public static bool IsQuantized(this MeasurementCollection items)
            {
                var first = items.First();
                return !items.All(i => first.Template.Frequency != Template.Frequency));
            }
