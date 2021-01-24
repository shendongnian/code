[HttpGet("")]
public List<EmployeeTable> GetUsers()
{
    var d = from e in context.Employee
        join s in context.Schedule on e.Id equals s.EmployeeId
        select new
        {
            Id = e.Id,
            Name = e.Name,
            Phone = e.PhoneNr,
            Mail = e.Mail,
            State = e.Active
        };
    return d.ToList();
}
