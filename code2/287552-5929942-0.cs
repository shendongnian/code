        private void button1_Click(object sender, EventArgs e) {
            using (var mf = new Form2()) {
                mf.FormClosing += delegate { MessageBox.Show("Dialog is closed."); };
                mf.ShowDialog();
            }
        }
