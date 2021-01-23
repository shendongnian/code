    static IEnumerable<T> SortSelectedIndices<T>(
        IEnumerable<T> values, 
        IEnumerable<int> selectedIndices, 
        Func<IEnumerable<T>, IEnumerable<T>> sort)
    {
        var selectedValues = new List<T>();
        for (var i = 0; i < selectedIndices.Count(); i++)
            selectedValues.Add(values.ElementAt(selectedIndices.ElementAt(i)));
        var sortedList = sort(selectedValues);
        var finalList = new List<T>();
        var startPositionFound = false;
        for(var i = 0; i < values.Count(); i++)
        {
            if (selectedIndices.Contains(i))
            {
                if (startPositionFound) continue;
                    
                startPositionFound = true;
                finalList.AddRange(sortedList);
            }
            else
                finalList.Add(values.ElementAt(i));
        }
        return finalList;
    }
