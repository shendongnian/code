    private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpFileName = "";
            try
            {
                helpFileName = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources") + @"\TextMag.chm";
                Help.ShowHelp(this, helpFileName);
               
            }
            catch (Exception ex)
            {
                string xxx = ex.Message;
            }
        }
