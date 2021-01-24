    foreach (ListViewItem li in listView1.Items)
        {
            foreach (var subItem in li.SubItems)
            {                           
                if (subItem.Text.ToString() == "Pending") {
                      li.BackColor = Color.Turquoise;
                      li.ForeColor = Color.White;
                  }
                else if (subItem.Text.ToString() == "Paid") {
                      li.BackColor = Color.Green;
                      li.ForeColor = Color.White;
                  }
                else if (subItem.Text.ToString() == "Over Due") {
                      li.BackColor = Color.Red;
                      li.ForeColor = Color.White;
                  }
            }
        }
