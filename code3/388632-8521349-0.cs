        public void ComboList1()
        {
            DataGridViewComboBoxColumn combo1 = new DataGridViewComboBoxColumn();
            combo1.HeaderText = "Country";
            combo1.Items.Add("Antarctica");
            combo1.Items.Add("Belgium");
            combo1.Items.Add("Canada");
            combo1.Items.Add("Finland");
            combo1.Items.Add("Albania");
            combo1.Items.Add("India");
            combo1.Items.Add("Barbados");
            dataGridView1.Columns.Add(combo1);
        } 
        public void ComboList2()
        {
            DataGridViewComboBoxColumn combo2 = new DataGridViewComboBoxColumn();
            combo2.HeaderText = "Types of Jobs";
            combo2.Items.Add("Accounting");
            combo2.Items.Add("HR");
            combo2.Items.Add("Finance");
            combo2.Items.Add("Transportation");
            combo2.Items.Add("Testing");
            dataGridView1.Columns.Add(combo2);
        }
