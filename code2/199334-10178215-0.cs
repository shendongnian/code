        int control =  0;
        private void hideShowLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (control == 0)
            {
                control = 1;
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = true;
            }
            else if (control == 1)
            {
                control = 0;
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
            }
        }
