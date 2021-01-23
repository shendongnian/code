    [HttpPost]
    public ActionResult JobHandlerUpdate(int jobScheduleId, JobHandlerList jobHandlerList)
    {
        var updateJobHander = new MainJobHandler();
        var item = updateJobHander.GetById(jobScheduleId);
        if (ModelState.IsValid)
        {
            List<string> days = jobHandlerList.JobProcessDayOfWeek.Split(',').ToList();
            updateJobHander.Update(item, days);
            if(jobHandlerList.MaxInstances == 0)
            {
                // Redirect to confirmation View
                return View("JobUpdateConfirmation");
            }
            return RedirectToAction("JobHandler");
        }
       return View(item);
    }
    [HttpPost]
    public ActionResult JobUpdateConfirmation()
    {
          // Code to update Job here
          // Notify success, eg. view with a message.
          return RedirectToAction("JobHandlerUpdateSuccess");
    }
