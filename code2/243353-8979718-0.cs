    public static void InitDGVComboBoxColumn<T>(DataGridViewComboBoxCell cbx, List<T> dataSource, String displayMember, String valueMember)
    {
        cbx.DisplayMember = displayMember;
        cbx.ValueMember = valueMember;
        cbx.DataSource = dataSource;
        if (cbx.Value == null)
        {
            if(dataSource.Count > 0)
            {
                T m = (T)cbx.Items[0];
                FieldInfo fi = m.GetType().GetField(valueMember, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                cbx.Value = fi.GetValue(m);
            }
        }
    }
