        bool isformWebleadOpen =false;
        private void leadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if(isformWebleadOpen == false)
          {
           formWeblead = new frmWebLeads();
           isformWebleadOpen =true;
           formWeblead.Closed += formWeblead_Closed;
           formWeblead.Show();
          }
       }
       void formWeblead_Closed(object sender, EventArgs e)
       {
         isformWebleadOpen = false;
       }
