    [Authorize(Policy = "EmployeeOnly")]
    public Task<IActionResult> GetEmployeeProfile(Guid employeeId)
    {
        ....
    }
