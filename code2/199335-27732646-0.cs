     bool state;
        private void btn_Click(object sender, EventArgs e)
        {
            if (state)
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2Collapsed = false;
                state = false;
                
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel2Collapsed = true;
                state = true;
                
            }
        }
