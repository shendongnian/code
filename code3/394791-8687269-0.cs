    public int? GetItem(int index)
    {
        int? value = null;
        try
        {
            value = this.array[index];
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        return value;
    }
