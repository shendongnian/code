    public static Control[] GetControls(Control findIn)
    {
        List<Control> allControls = new List<Control>();
        foreach (Control oneControl in findIn.Controls)
        {
            allControls.Add(OneControl);
            if (OneControl.Controls.Count > 0)
                allControls.AddRange(GetControls(oneControl));
        }
        return allControls.ToArray();
    }
