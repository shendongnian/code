    public override string GetHash()
    {
        int hashCode = 0;
        foreach (Vector3 val in this.v)
        {
            hashCode = CombineHashCodes(hashCode, val.X.GetHashCode());
            hashCode = CombineHashCodes(hashCode, val.Y.GetHashCode());
            hashCode = CombineHashCodes(hashCode, val.Z.GetHashCode());
        }
        foreach (Vector3 val in this.n)
        {
            hashCode = CombineHashCodes(hashCode, val.X.GetHashCode());
            hashCode = CombineHashCodes(hashCode, val.Y.GetHashCode());
            hashCode = CombineHashCodes(hashCode, val.Z.GetHashCode());
        }
        foreach (Vector2 val in this.u)
        {
            hashCode = CombineHashCodes(hashCode, val.X.GetHashCode());
            hashCode = CombineHashCodes(hashCode, val.Y.GetHashCode());
        }
        foreach (int val in this.t)
        {
            hashCode = CombineHashCodes(hashCode, val.GetHashCode());
        }
        return hashCode.ToString();
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int CombineHashCodes(int h1, int h2)
    {
        return ((h1 << 5) + h1) ^ h2;
    }
