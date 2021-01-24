    public ActionResult LeaveRequest()
    {
      var model = new LeaveRequestModel();
    
      if(condition)
      {
        model.FilteredLeaveStatus = new SelectList(new []{LeaveStatus.ApprovedBySpv, LeaveStatus.ApprovedByHr});
      }
      ...
      return View(model);
    }
