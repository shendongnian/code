    //yield the first row of each group
    private static IEnumerable<DataRow> Sort(IEnumerable<IGrouping<string, DataRow>> orderedEnumerableRowCollection)
        {
            var dataRows = orderedEnumerableRowCollection.ToArray();
            for (int i = 0; i < dataRows.Length; i++)
            {
                for (int j = 0; j < dataRows[i].Count(); j++)
                {
                    var array = dataRows[i].ToArray();
                    yield return array[j];
                }
            }
        }
