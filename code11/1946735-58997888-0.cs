    public int TryPopRange(T[] items, int startIndex, int count);
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     items is a null reference (Nothing in Visual Basic).
    //
    //   T:System.ArgumentOutOfRangeException:
    //     startIndex or count is negative. Or startIndex is greater than or equal to the
    //     length of items.
    //
    //   T:System.ArgumentException:
    //     startIndex + count is greater than the length of items.
