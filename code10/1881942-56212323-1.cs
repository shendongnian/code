    private async void btnMRFA_rminus_Click(object sender, EventArgs e) 
    {
          int ncpos = int.Parse(txtMRFA_cpos.Text);
         int nsteps = int.Parse(txtMRFA_steps.Text);
         Application.DoEvents(); 
        //note the negative 
         await MRFA_move(-nsteps); 
     }
