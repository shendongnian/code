            decimal totalPrice = 0;
            foreach (DataGridViewRow row in dataGridView_orders.Rows)
            {
                totalPrice += Convert.ToDecimal(row.Cells["price"].Value)).ToString();
            }
            textBox_totalPrice.Text = string.format("{0:#.00}", totalPrice);
        }
