    public IEnumerable<Control> GetAll(this Control control)
    {
        var controls = control.Controls.Cast<Control>();
    
        return controls.SelectMany(ctrl => ctrl.GetAll())
                                  .Concat(controls);
    }
