    public static void SynchCreativesForCampaign(int pid, ILogger logger)
    {
        var db = new SynchDbDataContext(true);
        CreativeEntity creativeEntity = null; // NEW: pull this out of the loop
        foreach (var creativeItem in CreativeList.Create(pid).CreativeItems)
        {
            logger.Log(@"creative id " + creativeItem.CreativeId);
            var creativeDetail = CreativeDetail.Create(creativeItem.CreativeId);
            if (creativeEntity != null) {
                continue; // NEW: let the loop go on, but make sure we only
                          // wrote to creativeEntity *once*
            }
            // IMPORTANT: notice I don't immediately call FirstOrDefault!
            creativeEntity = from c in db.CreativeEntities
                             where c.dtid == creativeItem.CreativeId
                             select c;
        }
        if (creativeEntity != null)
        {
            // Only NOW evaluate the query
            var result = creativeEntity.FirstOrDefault();
            // OK, stop: result holds the creative entity with the dtid
            // referring to which CreativeItem.CreativeId?
        }
    }
