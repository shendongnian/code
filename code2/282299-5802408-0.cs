    CollisionPrimitiveList[] cells = new CollisionPrimitiveList {
        innerGrid[cellIndex + 1],
        innerGrid[cellIndex + grid.XExtent],
        innerGrid[cellIndex + grid.XzLayerSize]
        // and all the rest
    };
    // Loop over cells - for demo only. Use for loop or LINQ'ify if faster
    foreach (CollisionPrimitiveList cell in cells) 
    {
        if (cell.Count > 0)
            contactsMade += collideWithCell(obj, cell, data, ref attemptedContacts);  
    }
