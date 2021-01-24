    private void btnMainMenu_MouseEnter(object sender, EventArgs e)
        {
            pnSideBlock.Left = -20;
    
            timerForAnim.Enabled = true;
        }
    
        private void btnMainMenu_MouseLeave(object sender, EventArgs e)
        {
            timerForAnim.Enabled = false;
        }
    
        private void timerForAnim_Tick(object sender, EventArgs e)
        {
            pnSideBlock.Left += 1;
            if(pnSideBlock.Left == 0)
            {
                timerForAnim.Enabled = false;
            }
        }
