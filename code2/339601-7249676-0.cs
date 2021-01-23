     private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Sorted +=new EventHandler(dataGridView1_Sorted);
        }
        void dataGridView1_Sorted(object sender, EventArgs e)
        {
            if (this.dataGridView1.SortOrder.Equals(SortOrder.Ascending))
            {
                // your code here
            }
            if (this.dataGridView1.SortOrder.Equals(SortOrder.Descending))
            {
                // your code here
            }
            if (this.dataGridView1.SortOrder.Equals(SortOrder.None))
            {
                // your code here
            }
        }
