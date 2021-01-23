    public override int GetHashCode()
    {
        unchecked
        {
            return (ColumnID*397) ^ (SubGroupID.HasValue ? SubGroupID.Value : 0);
        }
    }
