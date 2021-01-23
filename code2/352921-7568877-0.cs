        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.ToString().Equals("TAB") // I dont know what tab key returns. But is hould be something like this
            {
                  tabControl1.SelectedTab = tabControl1.TabPages[1] ;
                  // now tabpage 2 has the focus
                  // You can also focus any control you want in here as follows:
                  tabControl1.TabPages[1].Control["control key"].Focus();
            }
        }
