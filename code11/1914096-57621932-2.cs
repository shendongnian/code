    public IEnumerable<DepartmentDto> GetAllDepartments()
    {
        var departmentPaged = new Paged<Department>(departmentRepository.GetAll());
        return mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departmentPaged.GetPage(1, 3));
    }
