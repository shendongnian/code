        public Form1()
        {
            InitializeComponent();
            this.dt.AutoGenerateColumns = false;
            this.dt.MultiSelect = false;
            this.dt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Id column
            this.dt.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id", //Name of database column
                Name = "Id", //Display name of datagrid column
                Visible = false
            });
            //SomeValue Column
            this.dt.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SomeValue",
                Name = "Value"
            });
            //SomeString Column
            this.dt.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SomeString",
                Name = "String"
            });
        }
