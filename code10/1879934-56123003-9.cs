      public ActionResult BtnFinish()
        {
            var first = QueueHelper.TodayQueue.Dequeue();
            TempData["QueueItem"] = first;
    
            return RedirectToAction("Index");
        }
