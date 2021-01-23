    public class MyForm
    {
        private Window _openedWindow;
        private void ordresToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
            if ( _openedWindow != null &&  _openedWindow.Open)
            {
                //
            }
            else
            {
                Lordre newMDIChild = new Lordre(ClientId);
                _openedWindow = newMDIChild;
                // Set the Parent Form of the Child window.
                newMDIChild.MdiParent = this;
                // Display the new form.
                newMDIChild.Show();                
            }
        }
    }
