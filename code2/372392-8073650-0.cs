    var departmentMember = new DepartmentMember
                               {
                                   DepartmentId = 123,
                                   MemberId = person.Id
                               };
    dbContext.DepartmentMembers.Add(departmentMember);
    dbContext.SaveChanges();
