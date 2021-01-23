    for (int i = 0; i < population; i++)
    {
        int[] geneList = new int[numOFItems];
        for (int j = 0; j < numOFItems; j++)
        {
            geneList[j] = rand.Next(0, 4);
        }
        gen[i] = new Genome(geneList);
    }
