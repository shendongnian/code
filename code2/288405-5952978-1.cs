    public Chromosome(int[] initialGenes)
    {
        Genes = new int[initialGenes.Length];
        Array.Copy(initialGenes, Genes, Genes.Length);
    }
