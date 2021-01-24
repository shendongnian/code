     private void button1_Click(object sender, EventArgs e)
        {
            int num_items = listBox1.Items.Count;
            object[] items = new object[num_items];
            listBox1.Items.CopyTo(items, 0);
            // Sort them by their contained numeric values.
            items = SortNumericItems(items);
            // Display the results.
            listBox1.Sorted = false;
            listBox1.DataSource = items;
        }
     private object[] SortNumericItems(object[] items)
        {
            // Get the numeric values of the items.
            int num_items = items.Length;
            const string float_pattern = @"-?\d+\.?\d*";
            double[] values = new double[num_items];
            for (int i = 0; i < num_items; i++)
            {
                string match = Regex.Match(
                    items[i].ToString(), float_pattern).Value;
                double value;
                if (!double.TryParse(match, out value))
                    value = double.MinValue;
                values[i] = value;
            }
            // Sort the items array using the keys to determine order.
            Array.Sort(values, items);
            return items;
        }
