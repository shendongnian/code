    public ActionResult SetQueueInfo([Bind(Include = "QueueId,Name,QueueNumber,ServiceId,ServiceName,ServiceLetter")] Queue queue/*, int? id,string Name, string QueueNumber, string ServiceLetter, int ServiceId*/, int? id)
    {
        if (ModelState.IsValid)
        {
            QueueHelper.TodayQueue.Enqueue(queue);
            db.Queues.Add(queue);
            db.SaveChanges();
            return View(queue);
        }
    
        return View();
    }
