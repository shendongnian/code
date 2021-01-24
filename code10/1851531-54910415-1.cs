    public IEnumerable<Control> GetAll(this Control control,Type type)
    {
        var controls = control.Controls.Cast<Control>();
    
        return controls.SelectMany(ctrl => ctrl.GetAll(type))
                                  .Concat(controls)
                                  .Where(c => c.GetType() == type);
    }
[...]
    foreach (Button btn in frm.GetAll(typeof(Button)))
        {
            btn.BackColor = btnColor;
        }
