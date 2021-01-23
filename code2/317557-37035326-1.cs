        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmRep != null)
            {
                if (frmRep.Visible == false)
                {
                    frmRep = new frmReportes();
                    frmRep.MdiParent = this; frmRep.Show();
                }
                else
                {                    
                    frmRep.Activate();
                    return;
                }
            }
            else
            {
                frmRep = new frmReportes();
                frmRep.MdiParent = this; 
                frmRep.Show();
            }            
        }
