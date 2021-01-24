    // process shards
    private void ProcessShards()
    {
        // create a list for shards to process
        Queue<GameObject> shardsToProcess = new Queue<GameObject>();
        // select the first shard to process
        shardsToProcess.Enqueue(unprocessedShards[0]);
        // remove shard from unprocessed list
        unprocessedShards.Remove(unprocessedShards[0]);
        // loop while there are shards to process
        while (shardsToProcess.Count > 0)
        {
            // get the first shard to process
            GameObject shard = shardsToProcess.Dequeue();
            // add the shard to this chunk
            shard.GetComponent<Shard>().parentChunk = gameObject;
            // loop through all shards connected to the given shard
            foreach (GameObject connectedShard in shard.GetComponent<Shard>().connectedShards)
            {
                // connected shard has not been processed yet
                if (unprocessedShards.Contains(connectedShard))
                {
                    // add shard to be processed
                    shardsToProcess.Enqueue(connectedShard);
                    // remove shard from unprocessed list
                    unprocessedShards.Remove(connectedShard);
                }
            }
        }
    }
