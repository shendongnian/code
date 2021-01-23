        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUavController_KeyDown);
 
        private void frmUavController_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.W))
            {
                btnUp.PerformClick();
            }
            else if ((e.KeyCode == Keys.Down) || (e.KeyCode == Keys.S))
            {
                btnDown.PerformClick();
            }
            else if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.A))
            {
                btnLeft.PerformClick();
            }
            else if ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.D))
            {
                btnRight.PerformClick();
            }
        }
