    public static bool IsAllThat(this object x)
    {
        dynamic d = x;
        return d.IsThis || d.IsThat;
    }
