    public List<Service.Employee> GetEmployees(...)
    {
      IEnumerable<Data.Employee> dataEmployees = // Retrieve employees from data repository
      var serviceEmployees = dataEmployees.Select(dataEmployee => EntityConverter.ToServiceEntity(dataEmployee°);
      return serviceEmployees.ToList();
    }
