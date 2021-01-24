    // shuffle positions
    public void Shuffle()
    {
        for (int i = 0; i < positions.Count; i++)
        {
    // notice this -------------------------------------V
            int rnd = Random.Range(0, positions.Count - 1);
            Vector2 tempGO = positions[rnd];
            positions[rnd] = positions[i];
            positions[i] = tempGO;
        }
    }
