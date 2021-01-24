    var departmentsByProductType = unitOfWork.DbSet<Department>()
        .Where(d => d.ProductTypeDepartmentBridge.Any(b => b.ProductType.ProductTypeId == 5))
        .Select(d => new 
        {
            DepartmentId = d.DepartmentId,
            DepartmentName = d.DepartmentName
        });
