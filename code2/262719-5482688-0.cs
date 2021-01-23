    public BusinessEntityViewModel ConvertToViewModel(this BusinessEntity businessEntity)
    {
          BusinessEntityViewModel bevm = new BusinessEntityViewModel{ Id = businessEntity.Id, ...}
          return bevm;
    }
