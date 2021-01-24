    Class MessageBoxConstraints
    {
        public int Counter { get; set; } = 0; 
    
        public void Show ()
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
    class Program
    {
        static void Main()
        {
          
            var popUp = new MessageBoxConstraints();
            if(popUp.Counter<5)
            {
              popUp.Show();
            }
      
        }
    }
