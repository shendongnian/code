    [Audit]
    public ActionResult CreateLeavePrerequest(LeaveRequest leaveRequest)
    {
        SetTargetObject(leaveRequest);
        // ... I guess here the leaveRequest object is modified
        leaveRequest.SomeProp = "NewValue";
        UpdateTargetObject(leaveRequest);
    }
    private void SetTargetObject(object value)
    {
        var scope = this.GetCurrentAuditScope();
        scope.Event.Target = new AuditTarget
        {
            SerializedOld = scope.DataProvider.Serialize(value),
            Type = value.GetType().Name
        };
    }
    
    private void UpdateTargetObject(object value)
    {
        var scope = this.GetCurrentAuditScope();
        scope.Event.Target.SerializedNew = scope.DataProvider.Serialize(value);
    }
