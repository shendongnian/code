    private void GetControls(IEnumerable controls, IList<string> names)
    {
        foreach(var ctl in controls)
        {
            var name = ctl.GetType().GetProperty("Name");
            if (name != null)
                names.Add((string)name.GetValue(ctl, null));
            foreach (var property in ctl.GetType().GetProperties())
            {
                var prop = property.GetValue(ctl, null);
                if (prop is IEnumerable)
                    GetControls((IEnumerable)prop, names);
            }
        }
    }
    
