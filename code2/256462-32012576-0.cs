    [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "At least one item needs to be selected")]
    public int ItemCount
    {
        get
        {
            return Items != null ? Items.Length : 0;
        }
    }
