    override public bool Accomplish()
    {
        bool questAccomplished = true;
        foreach (var group in RequiredItems.GroupBy(x => x))
        {
            if (Application._player.InventoryItems.Count
                (
                    x =>
                    (
                       x.IsSame(group.Key)
                    )
                ) < group.Count())
            {
                questAccomplished = false;
                break;
            }
        }
    
        return questAccomplished;
    }
