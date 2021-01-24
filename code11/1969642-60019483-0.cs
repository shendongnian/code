        public Form1()
        {
            InitializeComponent();
            budgetTable.Columns.Add("id", typeof(Int32));
            budgetTable.Columns.Add("date", typeof(DateTime));
            budgetTable.Columns.Add("type", typeof(String));
            budgetTable.Columns.Add("name", typeof(String));
            budgetTable.Columns.Add("expenses", typeof(Int32));
            budgetTable.Columns.Add("income", typeof(Int32));
            budgetTable.Columns.Add("saldo", typeof(Int32));
            var date = DateTime.ParseExact("29MAR18", "ddMMMyy", CultureInfo.InvariantCulture);
            DataRow row = budgetTable.NewRow();
            row["id"] = "01";
            row["date"] = date;
            row["type"] = cbbxType.Text;
            row["name"] = nameField.Text;
            row["expenses"] = expenseField.Text;
            row["income"] = incomeField.Text;
            row["saldo"] = 0;
            budgetTable.Rows.Add(row);
            DtgTable.DataSource = budgetTable;
            budgetTable.Rows.Clear();
        }
        
        //adds a row to the table
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbxType.Text) ||
                string.IsNullOrWhiteSpace(expenseField.Text))
            {
                MessageBox.Show("'Type','Expence','Income' fields cannot be empty!");
            }
            else
                budgetTable.Rows.Add(null, dateTime.Text, cbbxType.Text, nameField.Text, expenseField.Text, incomeField.Text, 0);
        }
