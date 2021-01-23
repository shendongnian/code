    public object Value {
        get {
            if (string.IsNullOrEmpty(ValueMember)) {
                return Text;
            } else {
                return SelectedValue;
            }
        }
        set {
            if (DesignMode)
                return;
            // If we're databound, Value is the SelectedValue.  Otherwise, it's the Text.
            object oldValue = string.IsNullOrEmpty(ValueMember) ? Text : SelectedValue;
            // Want to make sure we're comparing apples to apples, and not specific instances of apples.
            string strOld = oldValue == null ? string.Empty : Convert.ToString(oldValue);
            string strNew = value == null ? string.Empty : Convert.ToString(value);
            if (!string.Equals(strOld, strNew, StringComparison.OrdinalIgnoreCase)) {
                if (ValueMember.HasValue) {
                    if (value != null && !string.IsNullOrEmpty(Convert.ToString(value))) {
                        SelectedItem = Items.OfType<object>.FirstOrDefault((System.Object i) => string.Equals(Convert.ToString(FilterItemOnProperty(i, ValueMember)), strNew, StringComparison.OrdinalIgnoreCase));
                    } else {
                        SelectedIndex = -1;
                    }
                } else {
                    Text = value != null ? value.ToString : string.Empty;
                }
                ValidateField();
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }
    }
