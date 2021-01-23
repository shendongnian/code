    AuditEventTask task;
    if (user.failLogic1) { task = new FailLogin1AuditEventTask(fail 1 params); }
    if (user.failLogic2) { task = new FailLogin2AuditEventTask(fail 2 params); }
    if (user.failLogic3) { task = new FailLogin3AuditEventTask(etc); }
    if (user.failLogic4) { task = new FailLogin4AuditEventTask(etc); }
    task.Log();
    user.Save();
