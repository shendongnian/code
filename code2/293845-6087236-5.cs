    public SettingMap()
    {
        Id(x => x.Id).GeneratedBy.Guid();
        HasOne(x => x.Student).Cascade.All();
    }
    public StudentMap()
    {
        Id(x => x.Id).GeneratedBy.Foreign("Setting");
        HasOne(x => x.Setting).Constrained();
    }
