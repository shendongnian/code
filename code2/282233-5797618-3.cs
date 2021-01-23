    public byte Similarity(SomeType other)
    {
        byte similarity = 0;
        if (this.Property1 == other.Property1)
            similarity += 25;
        if (this.Property2 == other.Property2)
            similarity += 13;
        if (this.Property3 == other.Property3)
            similarity += 12;
        if (SomeFuzzyComparisonReturnsVerySimilar(this.Property4, other.Property4))
            similarity += 50;
        return similarity;
    }
