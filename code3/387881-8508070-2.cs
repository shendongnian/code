        private void btnSearch1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.OnSearchClick += new OnSearch(frm2_OnSearchClick);
            frm2.Show();
        }
        void frm2_OnSearchClick(string employeeName)
        {
            MessageBox.Show(employeeName);
        }
