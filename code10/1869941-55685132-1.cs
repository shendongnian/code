    void Shuffle()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < positions.Count; i++)
        {
            int rnd = random.Next(0, positions.Count);
            Vector2 tempGO = positions[rnd];
            positions[rnd] = positions[i];
            positions[i] = tempGO;
        }
    }
