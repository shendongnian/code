    public static IEnumerable<IValueCollection> PivotValues(this MeasurementCollection items)
    {
        if(items.IsQuantized())
        {
            var elements = Enumerable.Range(0, (int)items.First().Template.Frequency);
            var itemArray = items.ToArray();
            foreach(var element in elements)
                yield return new MeasurementValueCollection(
                                     itemArray.Select( 
                                       (item,index) => itemArray[index].Value[element]
                                     )
                                 );
        }
        else
            yield break; // Handle the case where IsQuantized() returns false...
    }
