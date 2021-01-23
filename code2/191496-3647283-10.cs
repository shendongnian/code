    [HttpPost]
    public ActionResult Edit(
        Employee employee, // <<== serialized (detached) instance
        [Optional, DefaultParameterValue(0)] int teamId)
    {
        // ...
    
        // load team and containing Employees into the session
        var team = _teamRepository.GetById(teamId);
    
    
        // ...
    
        // store the detached employee. The employee may already be in the session,
        // loaded by the team query above. The detached employee is another instance
        // of an already loaded one. This is not allowed.
        _employeeRepository.SaveOrUpdate(employee);
    
        // ...
    }
