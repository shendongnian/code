        public static class DataTableHandler
        {
            private const string COL_PRICE = "PriceColumn";
            private const string COL_QUANTITY = "QuantityColumn";
            public static DataTable AddTotalRow(DataTable dataTable)
            {
                int totalQuantity = 0;
                decimal totalPrice = 0.0;
                CalculateTotals(dataTable, out totalQuantity, out totalPrice);
                DataRow row = dataTable.AddRow();
                row.Cells[COL_QUANTITY].Value = totalQuantity;
                row.Cells[COL_PRICE].Value = totalPrice;
                dataTable.Rows.Add(row);
                return dataTable;
            }
            private static void CalculateTotals(DataTable dataTable, out int totalQuantity, out decimal totalPrice)
            {
                totalPrice = 0.0;
                totalQuantity = 0;
                foreach (DataRow r in dataTable.Rows)
                {
                    totalPrice += (decimal)r.Cells[COL_PRICE].Value;
                    totalQuantity += (int)r.Cells[COL_QUANTITY].Value;
                }
            }
       }
