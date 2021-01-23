        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //get selected config object
                config conf = listBox1.SelectedItem as config;
                //fill extensions listbox
                listBox2.DataSource = config.Extensions;
            }
        }
