    private Dictionary<int, int> weights = new Dictionary<int, int>
    {
        // Value | Weight TODO: Make sure these sum up to 100
        {1,        9},
        {2,        9},
        {3,        9},
        {4,        9},
        {5,        9},
        {6,        1},
        {7,        9},
        {8,        9},
        {9,        9},
        {10,       9},
        {11,       9},
        {12,       9}
    };
    // for storing the weighted options
    private readonly List<int> weightedOptions = new List<int>();
    private void Start()
    {
        // first fill the randomResults accordingly to the given wheights
        foreach (var kvp in weights)
        {
            // add kvp.Key to the list kvp.value times
            for (var i = 0; i < kvp.Value; i++)
            {
                weightedOptions.Add(kvp.Key);
            }
        }
    }
    public int GetRandomNumber()
    {
        // get a random inxed from 0 to 99
        var randomIndex = Random.Range(0, weightedOptions.Count);
        // get the according value
        return weightedOptions[randomIndex];
    }
