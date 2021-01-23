    else if (block is BlockUIContainer)
    {
        var container = (BlockUIContainer)block;
        if (container.Child is Image)
        {
            Image image = (Image)container.Child;
            // ...
        }
    } 
