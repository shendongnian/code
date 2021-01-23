    public SettingMap()
    {
        Id(x => x.Id).GeneratedBy.Guid();
        References(x => x.Student).Unique().Cascade.All();
    }
    public StudentMap()
    {
        Id(x => x.Id).GeneratedBy.Guid();
        HasOne(x => x.Setting).Cascade.All().PropertyRef("Student");
    }
