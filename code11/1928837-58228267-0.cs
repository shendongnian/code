        private void runEISD_Click(object sender, EventArgs e)
        {
            // Create a new instance of Dictionary<string, string>
            foreach(ListViewItem v in dwgList.Items)
            {
                MessageBox.Show("DWG #" + v.SubItems[0].Text + "\nRev # " + v.SubItems[1].Text);
            }
        }
