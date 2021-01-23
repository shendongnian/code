    public MyEntityService
    {
      public MyEntity GetById(int id)
      {
        MyEntity myEntity = _repo.GetById(id);
        myEntity.WooFactor = _wooFactorGenerator.CalculateWooFactor(myEntity);
        return myEntity;
      }
    }
