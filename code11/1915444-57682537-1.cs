    // This should work....
    var departmentsByProductType = unitOfWork.DBSet<Productype>()
                .Where(p => p.ProductTypeId == 5)
                .SelectMany(p => p.ProductTypeDepartmentBridge.Department
                    .Select( d => new 
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName
                    }));
    // but if not, this will work...
    var departmentsByProductType = unitOfWork.DBSet<Productype>()
                .Where(p => p.ProductTypeId == 5)
                .SelectMany(p => p.ProductTypeDepartmentBridge
                    .Select( b => new 
                    {
                        DepartmentId = b.Department.DepartmentId,
                        DepartmentName = b.Department.DepartmentName
                    }));
