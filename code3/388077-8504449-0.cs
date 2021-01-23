    public void CheckForComboBox(Control crl)
    {
	foreach (Control crl in this) {
		if (crl is ComboBox && ((ComboBox)crl).Items.Count > 0) {
			((ComboBox)crl).SelectedIndex = 1;
		} else if (crl.Controls != null && crl.Controls.Count > 0) {
			CheckForComboBox(crl);
		}
	}
    }
