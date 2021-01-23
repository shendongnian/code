    public int? GetItem(int index)
    {
        int? value = null;
        try
        {
            value = this.array[index];
        }
        catch (IndexOutOfRangeException)
        {
        }
        return value;
    }
