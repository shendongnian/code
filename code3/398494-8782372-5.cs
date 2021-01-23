    public static int ValueAtSnapshotSlice(int slice, IEnumerable<DataAndTime> data)
    {
        var defaultData = data.Last();
    
        return data.Take(slice)
                   .DefaultIfEmpty(defaultData)
                   .Last().Data;
            
    }
