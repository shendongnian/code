    public void SetToolTipInstance(ToolStrip ts, ToolTip tt)
    {
        Type type = ts.GetType.BaseType;
        int propToolTip = Convert.ToInt32(type.GetField("PropToolTip", BindingFlags.NonPublic | BindingFlags.Static).GetValue(ts));
        dynamic ps = type.BaseType.GetProperty("Properties", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ts);
        ps.GetType.GetMethod("SetObject", BindingFlags.Instance | BindingFlags.Public).Invoke(ps, {propToolTip,tt});
    }
