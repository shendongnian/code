    public YourForm()
                {
                    InitializeComponent();
                    dataGridView1.DataSource = ctx.Users.Local.ToBindingList();
                    DataGridViewCheckBoxColumn newCol = new DataGridViewCheckBoxColumn();
                    DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                    cell.IndeterminateValue = false;
                    cell.TrueValue = true;
                    cell.FalseValue = false;
                    newCol.CellTemplate = cell;
                    newCol.HeaderText = "Select";
                    newCol.Name = "selected";
                    newCol.Visible = true;
                    newCol.ValueType = typeof(bool);
                    dataGridView1.Columns.Add(newCol);    
                }
