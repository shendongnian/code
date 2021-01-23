    public static bool IsQuantized(this MeasurementCollection items)
            {
                var first = items.FirstOrDefault();
                return first != null && items.Skip(1).All(i => first.Template.Frequency == i.Template.Frequency));
            }
