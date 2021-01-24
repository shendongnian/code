    public void AddToInventory(Item _item, int amount = 1)
    {
        if (!items.Contains(_item))
        {
            items.Add(_item);
            _item.stackSize = amount;
        }
        else
        {
            _item.stackSize += amount;
           FlushList(); //I don't know what this function is supposed to be doing.
        }
    }
