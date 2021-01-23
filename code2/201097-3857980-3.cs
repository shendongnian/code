    /// <summary>
    /// Swaps the values of X and Y atomically.
    /// </summary>
    public void Swap()
    {
        long orig, swapped;
        do
        {
            orig = Interlocked.Read(ref m_pair);
            swapped = orig << 32 | (uint)(orig >> 32);
        } while (Interlocked.CompareExchange(ref m_pair, swapped, orig) != orig);
    }
