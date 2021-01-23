     int trollCount = 0;
     private void TrollFrm_KeyDown(object sender, KeyEventHandler e)
     {
         if (trollCount == 0 && e.KeyDown == Key.T)
           {
                trollCount = 1;
                frm.Text = "Trololol - Troll Count:" + trollCount
           }
         else if (trollCount == 1 && e.KeyDown == Key.E)
           {
                trollCount = 2;
                frm.Text = "Trololol - Troll Count:" + trollCount
           }
         else if (trollCount == 2 && e.KeyDown == Key.S)
           {
                trollCount = 3;
                frm.Text = "Trololol - Troll Count:" + trollCount
           }
         else if (trollCount == 4 && e.KeyDown == Key.T)
           {
                trollCount = 4;
                this.Close();
           }
         else
            trollCount = 0;
