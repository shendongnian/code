    private static Queue<QueueTable> todayQueue = new Queue<QueueTable>();
    
    public ActionResult SetQueueInfo([Bind(Include = "QueueId,Name,QueueNumber,ServiceId,ServiceName,ServiceLetter")] QueueTable queue, int? id)
            {
                
                if (ModelState.IsValid)
                {
                    todayQueue.Enqueue(queue);
                    db.Queues.Add(queue);
                    db.SaveChanges();
                    return View(queue);
                }
                return View();
            }
    
            public ActionResult Reserve()
            {
                var first = todayQueue.Dequeue();
    
                // pass to view and handle it
                return View(first);
            }
    
            public ActionResult ResetQueue()
            {
                // reset queue after finish
                todayQueue = new Queue<QueueTable>();
            }
