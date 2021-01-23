    private void ProcessAndRemove(IList<Item> list)
    {
        foreach (var item in list.ToList())
        {
            if (item.DeterminingFactor > 10)
            {
                list.Remove(item);
            }
        }
    }
