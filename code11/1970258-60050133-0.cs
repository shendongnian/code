    [NotMapped]
    public MyFunkyEnum  MyFunkyEnumStatus
    {
        get => (MyFunkyEnum) Enum.Parse(typeof(MyFunkyEnum), status);
        set => status = value.ToString();
    }
