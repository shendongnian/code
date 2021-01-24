    public ActionResult LeaveRequest()
    {
      var model = new LeaveRequestModel();
    
      if(condition)
      {
          var filtered = new[]
          {
              new SelectListItem{Value = LeaveStatus.ApprovedBySpv, Text = "Rejected By SPV"},
              new SelectListItem{Value = LeaveStatus.ApprovedByHr, Text = "Approved by HR"}
          };
        model.FilteredLeaveStatus = new SelectList(filtered);
      }
      ...
      return View(model);
    }
