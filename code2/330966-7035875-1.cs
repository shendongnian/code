    private void button1_Click(object sender, EventArgs e) 
    {
        var cntls = GetAll(this, typeof(RadioButton));
        foreach (Control cntrl in cntls)
        {
            RadioButton _rb = (RadioButton)cntrl;
            if (_rb.Checked)
            {
                _rb.Checked = false;
            }
        }
    }
    public IEnumerable<Control> GetAll(Control control, Type type)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrls => GetAll(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
    }
