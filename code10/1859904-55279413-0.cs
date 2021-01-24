    public void MapCarIdToDepartment(int DepartmentId, List<Guid> carIds)
    {
        foreach (var item in carIds)
        {
           var departmentCar = new DepartmentCar
           {
               CarId = item,
               DepartmentId = DepartmentId
           };
           Save(departmentCar);
        }
    }
