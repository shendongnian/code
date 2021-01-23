                entities.Sort();
    
                List<x> repeatedItems = new List<x>();
    
                if (entities.Count > 1)
                {
                    if (entities[0].Equals(entities[1]))
                    {
                        repeatedItems.Add(entities[0]);
                    }
                }
    
                for (int i=0;i<entities.Count;i++)
                { 
                    if (i < entities.Count -1)
                    {
                        if (entities[i].Equals(entities[i+1]))
                        {
                            repeatedItems.Add(entities[i+1]);
                        }
                }
