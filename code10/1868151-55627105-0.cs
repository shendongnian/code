    public bool Join(int queueId, int userId)
        {
    		var someLock = ConcurrentQueuePlaceHolder.Queues[queueId];
            lock (someLock)
            {
                var numberOfUsersInQueue = _context.GetNumberOfUsersInQueue(queueId); <- Working
                if (numberOfUsersInQueue >= 10)
                {
                    throw new Exception("Queue is full.");
                }
                else
                {
                    _context.AddUserToQueue(queueId, userId); <- Working
                }
    
                numberOfUsersInQueue = _context.GetNumberOfUsersInQueue(queueId); <- Working
    
                if (numberOfUsersInQueue == 3)
                {
                    return true;
                }
            }
            return false;
    	}
