      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (var wait = new WaitingForm())
         {
           wait.Show();
           ArchiveFiles(); 
           Application.Exit();
         }
      }
