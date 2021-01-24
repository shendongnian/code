    public Foo2ViewModel GetViewModelFromEntity(Entity entity)
    {
        Foo2ViewModel vm = (Foo2ViewModel) GetBaseFooViewModelFromEntity(entity);
        return vm;
    }
    public BaseFooViewModel GetBaseFooViewModelFromEntity(Entity entity)
    {
        return new BaseFooViewModel()
        {
            BaseFooField1 = entity.BaseFooField1,
            BaseFooField2 = entity.BaseFooField2,
            BaseFooField3 = entity.BaseFooField3
        };
    }
