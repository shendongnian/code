    private static List<List<KeyValuePair<string, int>>> GetAll3LetterCombos(Dictionary<string, int> values)
    {
        var comboList = new List<List<KeyValuePair<string, int>>>();
        for (int outer = 0; outer < values.Count; outer++)
        {
            for (int mid = outer + 1; mid < values.Count; mid++)
            {
                for (int inner = mid + 1; inner < values.Count; inner++)
                {
                    var combo = new List<KeyValuePair<string, int>>
                    {
                        values.ElementAt(outer),
                        values.ElementAt(mid),
                        values.ElementAt(inner)
                    };
                    comboList.Add(combo);
                }
            }
        }
        return comboList;
    }
