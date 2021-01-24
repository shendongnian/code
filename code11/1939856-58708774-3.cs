    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.dataGridView1.DataSource = new BindingList<Test>() {
            new Test(){ MyProperty1 = 1, MyProperty2= null},
            new Test(){ MyProperty1 = 2, MyProperty2= true},
            new Test(){ MyProperty1 = 3, MyProperty2= false},
        };
        UseCheckBoxForNullableBool(dataGridView1);
    }
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
