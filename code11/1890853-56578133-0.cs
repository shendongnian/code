    [HttpGet("Users")]
    public List<EmployeeTable> GetUsers()
    {
    var empDetails=context.Employee.join(context.Schedule,e=>e.Id,d=>d.Id,(e,d)=>new {
                Id = e.Id,
                Name = e.Name,
                Start = d.Start,
                End = d.End,
                Active = d.Active
    return (List<EmployeeTable>)(Object)empDetails.ToList();
    });
    }
