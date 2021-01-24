    for(int x = 0; x < items.Length; x++)
    {
        if (x > 3 ) 
             continue; // outer continue
        for(int y = 0; y < items.Length; y++)
        {
           continue; // inner continue
        }
    }
