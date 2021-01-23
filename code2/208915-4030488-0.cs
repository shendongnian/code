    static int BiasedRandom(Random rng, params int[] chances)
    {
        int sum = chances.Sum();
        int roll = rng.Next(sum);
        for (int i = 0; i < chances.Length - 1; i++)
        {
            if (roll < chances[i])
            {
                return i;
            }
            roll -= chances[i];
        }
        return chances.Length - 1;
    }
