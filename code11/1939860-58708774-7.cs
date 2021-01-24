    public void UseCheckBoxForNullableBool(DataGridView g)
    {
        g.Columns.Cast<DataGridViewColumn>()
            .Where(x => x.ValueType == typeof(bool?))
            .ToList().ForEach(x =>
            {
                var index = x.Index;
                g.Columns.RemoveAt(index);
                var c = new DataGridViewCheckBoxColumn();
                c.ValueType = x.ValueType;
                c.ThreeState = true;
                c.DataPropertyName = x.DataPropertyName;
                c.HeaderText = x.HeaderText;
                c.Name = x.Name;
                g.Columns.Insert(index, c);
            });
    }
