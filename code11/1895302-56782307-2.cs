    private static (int PackSize, int Quantity)[] GetBestCombination(
        int[] packSizes, int quantity)
    {
        var sequences = packSizes
            .Select(p => Enumerable.Range(0, (quantity / p) + 1)
                .Select(q => p * q))
            .ToArray();
        var cartesianProduct = CartesianProduct(sequences);
        int[] selected = null;
        int maxValue = Int32.MinValue;
        foreach (var combination in cartesianProduct)
        {
            int sum = combination.Sum();
            if (sum > quantity) continue;
            if (sum > maxValue)
            {
                maxValue = sum;
                selected = combination;
            }
        }
        if (selected == null) return null;
        return selected.Zip(packSizes, (sum, p) => (p, sum / p)).ToArray();
    }
