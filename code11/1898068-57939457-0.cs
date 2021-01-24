    private static decimal SumToDecimalSseFasterInner(this ulong[] arrayToSum, int l, int r)
    {
        decimal overallSum = 0;
        var sumVector    = new Vector<ulong>();
        var newSumVector = new Vector<ulong>();
        var zeroVector   = new Vector<ulong>(0);
        int sseIndexEnd = l + ((r - l + 1) / Vector<ulong>.Count) * Vector<ulong>.Count;
        int i;
        for (i = l; i < sseIndexEnd; i += Vector<ulong>.Count)
        {
            var inVector = new Vector<ulong>(arrayToSum, i);
            newSumVector = sumVector + inVector;
            Vector<ulong> gteMask = Vector.GreaterThanOrEqual(newSumVector, sumVector);         // if true then 0xFFFFFFFFFFFFFFFFL else 0L at each element of the Vector<long>
            if (Vector.EqualsAny(gteMask, zeroVector))
            {
                for(int j = 0; j < Vector<ulong>.Count; j++)
                {
                    if (gteMask[j] == 0)    // this particular sum overflowed, since sum decreased
                    {
                        overallSum += sumVector[j];
                        overallSum += inVector[ j];
                    }
                }
            }
            sumVector = Vector.ConditionalSelect(gteMask, newSumVector, zeroVector);
        }
        for (; i <= r; i++)
            overallSum += arrayToSum[i];
        for (i = 0; i < Vector<ulong>.Count; i++)
            overallSum += sumVector[i];
        return overallSum;
    }
