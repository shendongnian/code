    public static void SetComboBoxSelectionByValue<T>(ComboBox ctrl, int? value)
    {
        //  If the ComboBox has no items, disable it  (so the user can immediately see there's nothing selectable)
        ctrl.Enabled = (ctrl.Items.Count > 0);
    
        int inx = 0;
        foreach (T t in ctrl.Items)
        {
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                if (info.Name == ctrl.ValueMember)
                {
                    object val = info.GetValue(t, null);
                    if (val.ToString() == value.Value.ToString())
                    {
                        ctrl.SelectedIndex = inx;
                        return;
                    }
                }
            }
            inx++;
        }
    
        if (ctrl.Items.Count > 0)
            ctrl.SelectedIndex = 0;
    }
