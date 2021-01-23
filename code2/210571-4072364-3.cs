    private static Random rand = new Random();
    public static T ChooseRandomOutcome<T>(Dictionary<T,int> relativeWeights)
    {
        Random rand = new Random();
        var total = relativeWeights.Values.Sum();
        var randomValue = rand.Next(total);
        var runningSum = 0;
        foreach (var pair in relativeWeights)
        {
            if (randomValue < pair.Value)
            {
                return pair.Key;
            }
            runningSum += pair.Value;
        }
        throw new Exception("This should never happen.");    
    }
