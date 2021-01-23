    public static bool IsQuantized(this MeasurementCollection items)
            {
                var first = items.First();
                return items.Skip(1).All(i => first.Template.Frequency == i.Template.Frequency));
            }
