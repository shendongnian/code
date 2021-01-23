        private void myTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                myTreeView.SelectedNode = myTreeView.HitTest(e.Location).Node;
            }
        }
