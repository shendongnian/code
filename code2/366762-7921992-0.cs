    List<byte[]> piks;
    // Fill piks...
    int zeroValuesCount = 0;
    foreach (var pik in piks) {
        zeroValuesCount += pik.Count(x => x == 0);
    }
