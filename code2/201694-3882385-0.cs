    ContractBase Foo() {
      Base obj = GetObject();
      var sourceType = obj.GetType();
      var destinationType = Mapper.GetAllTypeMaps().
        Where(map => map.SourceType == sourceType).
        // Note: it's assumed that you only have one mapping for the source type!
        Single(). 
        DestinationType;
      return (ContractBase)Mapper.Map(obj, sourceType, destinationType);
    }
