    TextBox _textBox;
    protected override void SetupEditControls()
    {
        base.SetupEditControls();
        _textBox = (TextBox)EditControl;
        var value = CustomerTypeBox.Value ?? string.Empty;
        if (String.IsNullOrEmpty(value.ToString()))
        {
            _textBox.Text = "Default text";
        }
        else
        {
            _textBox.Text = value.ToString();
        }
        if (_textBox != null) EditControl.Parent.Controls.Add(_textBox);
    }
    public override void ApplyEditChanges()
    {
        var customerTypeBoxValue = _textBox.Text;
        if (customerTypeBoxValue != null)
        {
            SetValue(customerTypeBoxValue);
        }
    }
