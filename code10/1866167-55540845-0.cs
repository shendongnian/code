    [Audit]
    public ActionResult CreateLeavePrerequest(LeaveRequest leaveRequest)
    {
        SetTargetObject(() => leaveRequest);
        // ...
        // I guess here the leaveRequest object is modified
        leaveRequest.SomeProp = "NewValue";
    }
    private void SetTargetObject(Func<object> valueGetter)
    {
        var scope = this.GetCurrentAuditScope();
        var value = valueGetter.Invoke();
        scope.Event.Target = new AuditTarget
        {
            SerializedOld = scope.DataProvider.Serialize(value),
            Type = value.GetType().Name
        };
    }
