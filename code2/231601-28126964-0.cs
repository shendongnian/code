    private void btn_Add_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem lvsi1 = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem lvsi2 = new ListViewItem.ListViewSubItem();
            lvi.Text = tb_Main.Text;
            lvsi1.Text = tb_Sub1.Text;
            lvsi2.Text = tb_Sub2.Text;
            lvi.UseItemStyleForSubItems = false;
            lv_List.ForeColor = Color.Black;
            if (lvsi1.Text == tb_Different.Text)
            {
                lvsi1.ForeColor = Color.Red;
            }
            if (lvsi2.Text == tb_Different.Text)
            {
                lvsi2![enter image description here][2].ForeColor = Color.Red;
            }
            lv_List.Items.Add(lvi);
            lvi.SubItems.Add(lvsi1);
            lvi.SubItems.Add(lvsi2);
        }
