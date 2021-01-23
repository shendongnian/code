    public IEnumerable<Control> GetAllControlsOfType(Control control, Type type)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => GetAllControlsOfType(ctrl, type))
                                  .Concat(controls)
                                  .Where(c => c.GetType() == type);
    }
