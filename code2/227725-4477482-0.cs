    public static Service.Employee ToServiceEntity(Data.Employee dataEmployee)
    {
        Service.Employee result = new Service.Employee();
        result.FirstName = dataEmployee.FirstName;
        ...
        return result;
    }
