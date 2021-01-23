    try
    {
        if (ModelState.IsValid)
        {
            var newduedate = DateHelper.GoodDate(duedate, duetime);
            _service.SetTaskDueDate(houseid, taskid, newduedate);
            return RedirectToAction("TaskDetail");
        }
    }
    catch (RulesException ex)
    {
        ex.CopyTo(ModelState);
    }
