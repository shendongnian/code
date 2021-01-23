     foreach( var entry in choices)
     {
        if(entry.IsSelected)
        {
             return entry.GetWorker();
             //Can't remember if i need to break after return..doubt it
        }
     }
    
