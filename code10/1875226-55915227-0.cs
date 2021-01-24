    public static IEnumerable<Solution> GetAllSolutions()
    {
        for (int day = 0; day < 3; day++)
        {
            for (int ev = 0; ev < 3; ev++)
            {
                yield return new Solution(); // ???
            }
        }
    }
