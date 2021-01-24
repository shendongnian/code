        private void button1_Click(object sender, EventArgs e)
        {
            var rp= listbox1.SelectedItem.ToString();
            if (rp == "Daily Call Data")
            {
                MessageBox.Show("day");
            }else if(rp == "Weekly Call Data")
            {
                MessageBox.Show("week");
            }
        }
        
