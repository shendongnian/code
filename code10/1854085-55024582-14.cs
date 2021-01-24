    public TFooModel GetBaseFooViewModelFromEntity<TFooModel>(Entity entity)
        where TFooModel : BaseFooViewModel, new()
    {
        return new TFooModel()
        {
            BaseFooField1 = entity.BaseFooField1,
            BaseFooField2 = entity.BaseFooField2,
            BaseFooField3 = entity.BaseFooField3
        };
    }
