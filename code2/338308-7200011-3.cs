        private void MainForm_FormClosing(object sender, FormClosingEventArgs e){
        
            if (!mailsent)
            {
                MessageBox.Show("Please wait, Mail Sending in Process !!! ");
                e.Cancel = true;
            }
        }
