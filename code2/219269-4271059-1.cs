    foreach (rect in rectangles)
    {
        owner = null
        foreach (possible_owner in rectangles)
        {
            if (possible_owner != rect)
            {
                if (possible_owner.contains(rect))
                {
                    if (owner === null || owner.Contains(possible_owner))
                    {
                        owner = possible_owner;
                    }
                }
            }
        }
        // at this point you can record that `owner` contains `rect`
    }
