	public ComboBox bindCombo(ComboBox _cb, DataTable _dt)
        {
	_cb.DataSource = _dt;
	_cb.BindingContext = new BindingContext();
	_cb.ValueMember = _dt.Columns[0].ToString();
	_cb.DisplayMember = _dt.Columns[0].ToString();
	return _cb;
	}
