    override public bool Accomplish()
    {
        bool questAccomplished = true;
        foreach (var group in RequiredItems.GroupBy(x => x))
        {
            if (Application._player.InventoryItems.Count
                (
                    x =>
                    (
                        x is Items.Tool && 
                        x.Name == group.Key.Name && 
                        ((Items.Tool)x).Material == group.Key.Material &&
                        ((Items.Tool)x).Classification == group.Key.Classification
                    )
                ) < group.Count())
            {
                questAccomplished = false;
                break;
            }
        }
    
        return questAccomplished;
    }
