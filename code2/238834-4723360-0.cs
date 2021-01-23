        public class MyGridForm: Form
        {
            private const string COL_PRICE = "PriceColumn";
            private const string COL_QUANTITY = "QuantityColumn";
            private DataGridView dataGridView = new DataGridView();
            private void InitializeGrid()
            {
                this.Controls.Add(dataGridView);
                dataGridView.ColumnCount = 2;
                DataGridViewColumn column = dataGridView.Columns[0];
                column.ValueType = typeof(int);
                column.HeaderText = "Quantity";
                column.Name = COL_QUANTITY;
                column = dataGridView.Columns[1];
                column.ValueType = typeof(decimal);
                column.HeaderText = "Price";
                column.Name = COL_PRICE;
                dataGridView.DataSource = yourDataSource;
                dataGridView.DataBind();
                DataGridViewRow row = new DataGridViewRow(); 
                dataGridView.Rows.Add(row);
            }
        }
