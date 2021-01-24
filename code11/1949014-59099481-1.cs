    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSharedView(    int workShiftId, 
                                                          SharedViewModel sharedViewModel, 
                                                          SurveyViewModel surveyViewModel,
                                                          WorkShiftTask task)
    {
          task.WorkShiftTaskId = workShiftId;
    }
