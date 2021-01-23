        private void listView1_MouseUp(object sender, MouseEventArgs e) {
            var hit = listView1.HitTest(e.Location);
            if (hit.SubItem != null && hit.SubItem == hit.Item.SubItems[1]) {
                var url = new Uri(hit.SubItem.Text);
                // etc..
            }
        }
