        bool listUpdated = false;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (!listUpdated) {
                this.BeginInvoke(new MethodInvoker(updateList));
                listUpdated = true;
            }
        }
        private void updateList() {
            listUpdated = false;
            // etc...
        }
