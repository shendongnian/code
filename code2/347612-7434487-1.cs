    List<EmailQueue> emailQueue =
        _repository.Select<EmailQueue>().Where(x => x.EmailStatuses.EmailStatus == "Pending").ToList();
    ThreadPool.QueueUserWorkItem(ProcessEmailQueue, emailQueue);
    void ProcessEmailQueue(object state)
    {
        List<EmailQueue> emailQueue = (List<EmailQueue>)state;
        foreach (var message in EmailQueue)
        {
            // Format and send message here.
        }
    }
