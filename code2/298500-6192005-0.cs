    protected virtual void SetComboData(System.Windows.Forms.Control parentCtrl, DataRow r)
    {
        foreach (System.Windows.Forms.Control ctrl in parentCtrl.Controls)
        {
            if (ctrl is ComboBox)
                if ((ctrl as ComboBox).DataBindings.Count != 0)
                    (ctrl as ComboBox).SelectedValue = r[(ctrl as ComboBox).DataBindings[0].BindingMemberInfo.BindingMember];
            if (ctrl is TextBox)
                if ((ctrl as TextBox).DataBindings.Count != 0)
                    (ctrl as TextBox).Text = r[(ctrl as TextBox).DataBindings[0].BindingMemberInfo.BindingMember].ToString();
            SetLecData(ctrl, r);
        }
    }
