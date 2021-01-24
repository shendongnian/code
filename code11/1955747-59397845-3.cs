    Class MessageBoxConstraints
    {
        public int Counter { get; set; } = 0; 
    
        public void Show()
        {
            if(Counter<5)
            {
              Initiate();
            }
      
        }
        
        private void Initiate ()
        {
            Counter++;
            DialogResult answer = MessageBox.Show("Would you like to add an additional driver to policy?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information); ;
                if (answer == DialogResult.Yes)
                {
                    frmAdditionalDriver form = new frmAdditionalDriver();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    frmInsurancePolicy form = new frmInsurancePolicy();
                    form.Show();
                    this.Hide();
                }
    
        }
        
    }
