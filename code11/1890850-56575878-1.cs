    public List<EmployeeWithScheduleModel> GetUsers()
    {
        var data = context.Employee.Include(c=>c.Schedule).ToList();
    
        var response = new List<EmployeeWithScheduleModel>();
    
        foreach (var item in data)
        {
            if(!item.Schedule.Any() || item.Schedule.Count > 1) continue; //your custom logic here
           var schedule = item.Schedule.FirstOrDefault();
           
    
           var employeeWithSchedule = new EmployeeWithScheduleModel
           {
              Id = item.Id,
              Name = item.Name,
              Start = schedule.Start,
              End = schedule.End,
              Active = schedule.Active
           };
    
           response.Add(employeeWithSchedule);
        }     
    
        return response;
    }
