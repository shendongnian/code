    private void GetControls(ICollection controls, IList<string> names)
    {
        foreach (var ctl in controls)
        {
            if (ctl is IComponent)
            {
                var name = ctl.GetType().GetProperty("Name");
                if (name != null)
                    names.Add((string) name.GetValue(ctl, null));
                foreach (var property in ctl.GetType().GetProperties())
                {
                    var prop = property.GetValue(ctl, null);
                    if (prop is ICollection)
                        GetControls((ICollection)prop, names);
                }
            }
        }
    }
    
