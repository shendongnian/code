        public List<DepartmentDTO> ListDetail()
        {
            using (var context = new AttendanceDBContext())
            {
                var departments = from d in context.Departments
                                  join dd in context.Departments on d.ParentDepartmentId equals dd.DepartmentId into ddd
                                  from dddd in ddd.DefaultIfEmpty()
                                  select new DepartmentDTO
                                  {
                                      DepartmentId = d.DepartmentId,
                                      Description = d.Description,
                                      ParentDepartment = dddd.Description,
                                      UserCount = d.GetDepartmentUsers.Count(),
                                      CreatedDate = d.CreatedDate,
                                      UpdatedDate = d.UpdatedDate
                                  };
                return departments.ToList();
            }
        }
