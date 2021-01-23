    public static string GetInfo(Base instance)
    {
        var attr = instance.GetType()
            .GetCustomAttributes(typeof(InfoAttribute), true)
            .FirstOrDefault();
        return (attr == null) ? null : attr.Info;
    }
