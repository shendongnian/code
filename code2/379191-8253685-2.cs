     int trollCount = 0;
     private void TrollFrm_KeyDown(object sender, KeyEventHandler e)
     {
         if (trollCount == 0 && e.KeyCode == Keys.T)
           {
                trollCount = 1;
                frm.Text = "Trololol - Troll Count:" + trollCount
           }
         else if (trollCount == 1 && e.KeyCode== Keys.E)
           {
                trollCount = 2;
                frm.Text = "Trololol - Troll Count:" + trollCount
           }
         else if (trollCount == 2 && e.KeyCode== Keys.S)
           {
                trollCount = 3;
                frm.Text = "Trololol - Troll Count:" + trollCount
           }
         else if (trollCount == 4 && e.KeyCode== Keys.T)
           {
                trollCount = 4;
                this.Close();
           }
         else
            trollCount = 0;
