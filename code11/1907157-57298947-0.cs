    public static IEnumerable<Control> GetAllControls(Control container)
    {
        List<Control> controlList = new List<Control>();
        foreach (Control c in container.Controls)
        {
            controlList.AddRange(GetAllControls(c));
            controlList.Add(c);
        }
        return controlList;
    }
