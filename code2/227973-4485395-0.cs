        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            switch (e.Node.Name) {
                case "Node0": embedForm(new Form2()); break;
                // etc..
            }
        }
        private void embedForm(Form frm) {
            // Remove existing form
            foreach (Control ctl in panel1.Controls) ctl.Dispose();
            panel1.Controls.Clear();
            // Embed new one
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;
            panel1.Controls.Add(frm);
        }
