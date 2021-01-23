            var prior = Form.ActiveForm;
            using (var dlg = new Form2()) {
                dlg.FormClosing += delegate { prior.Show(); };
                prior.Hide();
                if (dlg.ShowDialog() == DialogResult.OK) {
                    MessageBox.Show("result");
                }
            }
