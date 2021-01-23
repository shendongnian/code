    private void listView1_MouseDoubleClick(object sender, EventArgs e)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string s = item.SubItems[6].Text;
                q = m;
                CommercialOfferEditProperties ob = new CommercialOfferEditProperties(s, q);
                ob.FormClosed += new FormClosedEventHandler(ob_FormClosed);
                ob.ButtonClicked += new EventHandler(ob_ButtonClicked);
                ob.Show(); //show child
            }
    
            void ob_FormClosed(object sender, FormClosedEventArgs e)
            {
               //process form close
            }
    
            void ob_ButtonClicked(object sender, EventArgs e)
            {
               //process button clicked
            }
