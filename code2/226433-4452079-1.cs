        private void ShowOptionsButton_Click(object sender, EventArgs e) {
            using (var dlg = new Form2()) {
                dlg.ApplyChanges += new EventHandler(dlg_ApplyChanges);
                dlg.ShowDialog(this);
            }
        }
        void dlg_ApplyChanges(object sender, EventArgs e) {
            var dlg = (Form2)sender;
            // etc..
        }
