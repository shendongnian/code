    public static readonly IList<IList<int>> array;
    static Tables() {
        // Init array
        // Make it read only
        List<IList<int>> ar1 = new List<IList<int>>();
        for (int i = 0; i < 10; i++)
        {
            List<int> ar2 = new List<int>();
            for (int j = 0; j < 10; j++)
            {
                ar2.Add(j);
            }
            ar1.Add(ar2.AsReadOnly());
        }
        array = ar1.AsReadOnly();
    }
