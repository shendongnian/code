    public static readonly Dictionary<SetType, Constants> ConstantSets =
        new Dictionary<SetType, Constants> {
            [SetType.Set1] = new Constants { Name = "Set 1", Health = 100, MaxTries = null },
            [SetType.Set2] = new Constants { Name = "Set 2", Health = 80, MaxTries = 5 },
            ...
        };
