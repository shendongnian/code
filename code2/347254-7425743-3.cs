    [CheckRole(Role.Supervisor, Role.Manager)]
    public ActionResult ApproveLeavingRequest()
    {
        //the roles in the constructor of CheckRoleAttribute are OR related
    }
    [CheckRole(Role.Manager|Role.Supervisor, Role.Admin)]
    public ActionRequest ModifySystemSettings()
    {
        //this method is provided to a small group of people
        //those who is a manager and a supervisor
        //or he is an admin
    }
    [CheckRole(Role.Manager|Role.Supervisor|Role.Admin)] 
               //maybe we need to add Role.Boss into the system :)
    public ActionRequest IncreasePay()
    {
        //only the boss account can invoke this method
    }
