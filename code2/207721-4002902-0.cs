    // We use a dictionary here for efficiency
    var Updating = new Dictionary()<TheXMLObjectType, object>;
    
    ...
    if (de >= DateTime.Now)
    {
        return finalXML();
    }
    else
    {
        // Lock the updating dictionary to prevent other threads from
        // updating it before we're done.
        lock (Updating)
        {
            // If the xml is already in the updating dictionary, it's being
            // updated elsewhere, so we don't need to do anything.
            // On the other hand, if it's not already being updated we need
            // to queue RefreshFinalXml, and set the updating flag
            if (!Updating.ContainsKey(xml))
            {
                // Use the thread pool for the work, rather than managing our own
                ThreadPool.QueueUserWorkItem(delegate (Object o)
                {
                    RefreshFinalXml();
                    lock(Updating)
                    {
                        Updating.Remove(xml);
                    }
                });
                // Set the xml in the updating dictionary
                Updating[xml] = null;
            }
        }
        return finalXML();
    }
