    private readonly IUserService _userService;
    
    public MyController(IUserService userService)
    {
        _userService = userService;
    }
    public IActionResult ApproveUserChangeRequest([FromBody] ApproveUserChangeRequests approveUserChangeRequests)
    {
        // ... snip
        // this now uses the instance that was provided by dependency injection
        var result = _userService.ApproveUserChangeRequest(approveUserChangeRequests);
    }
