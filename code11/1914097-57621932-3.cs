    public Task<IEnumerable<DepartmentDto>> GetAllDepartments()
    {
        var departmentPaged = new Paged<Department>(departmentRepository.GetAll());
        return Task.FromResult(mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departmentPaged.GetPage(1, 3)));
    }
