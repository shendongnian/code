            private void radListView1_MouseDown(object sender, MouseEventArgs e)
        {
            SimpleListViewVisualItem elementUnderMouse = this.radListView1.ElementTree.GetElementAtPoint(e.Location) as SimpleListViewVisualItem;
            if (elementUnderMouse != null)
            {
                this.radListView1.SelectedItem = elementUnderMouse.Data ;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(radListView1.SelectedItem.Text.ToString());
            {
                testName = sb.ToString();
            }
            MessageBox.Show(testName);
        }
