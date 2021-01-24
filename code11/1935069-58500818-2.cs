    this.CreateMap<Entity, Model>()
        .ReverseMap()
        .ForMember(destEntity => destEntity.RowVersion, opt => opt.Ignore())
        .AfterMap((srcModel, destEntity) =>
        {
            for (int i = 0; i < srcModel.RowVersion.Length; i++)
            {
                destEntity.RowVersion[i] = srcModel.RowVersion[i];
            }
        });
