    public override void OnApplyTemplate()
    {
        try
        {
            base.OnApplyTemplate();
            myCombo.ApplyTemplate();
            TextBox tb = myCombo.Template.FindName("PART_EditableTextBox", myCombo) as TextBox;
            if (tb != null)
            {
                tb.SetBinding(TextBox.BackgroundProperty, myCombo.GetBindingExpression(ComboBox.BackgroundProperty).ParentBindingBase);
            }
            else
            {
                /* etc. */
            }
        }
        catch (Exception) { /* etc. */}
    }
