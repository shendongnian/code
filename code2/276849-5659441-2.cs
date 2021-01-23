    public ActionResult StartTask()
    {
        // Fire the task
        Task.Factory.StartNew(() => 
        {
            // TODO: the task goes here
            // Remark: Ensure you handle exceptions
        });
    
        // return immediately
        return Json(
            new { Message = "Task started" }, 
            JsonRequestBehavior.AllowGet
        );
    }
