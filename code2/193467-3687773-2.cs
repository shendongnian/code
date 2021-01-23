    public static IEnumerable<IValueCollection> PivotValues(this MeasurementCollection items)
    {
        if(items.IsQuantized())
        {
            int elementLength = (int)items.First().Template.Frequency;
            var itemArray = items.ToArray();
            for (int n = 0; n < itemArray.Length; n++)
            {
                IValueCollection v = new MeasurementValueCollection(elementLength);
                for (int m = 0; m < elementLength; m++)
                {
                    v[m] = itemArray[m].Values[n];
                }
                yield return v;
            }
        }
        else
            yield break; // Handle the case where IsQuantized() returns false...
    }
