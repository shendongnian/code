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
