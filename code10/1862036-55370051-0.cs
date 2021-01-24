        private void TX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sumF;
                sumF = Convert.ToInt32(Lb1PriceF.Text) * Convert.ToInt32(TX1.Text);
                Lb1SumF.Text = Convert.ToString(sumF); //Label1 sum
                
                // Call to update sum
                UpdateSum();
            }
            catch
            {
                Lb1SumF.Text = "0";
            }
        }
        private void TX2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sumF;
                sumF = Convert.ToInt32(Lb2PriceF.Text) * Convert.ToInt32(TX2.Text);
                Lb2SumF.Text = Convert.ToString(sumF); //Label2 sum
                // Call to update sum
                UpdateSum();
            }
            catch
            {
                Lb2SumF.Text = "0";
            }
        }
        // private void Lb3_TextChanged(object sender, EventArgs e)
        private void UpdateSum()
        {
               int sum = 0;
               
               if(!string.IsNullOrEmpty(Lb1SumF.Text) && !string.IsNullOrEmpty(Lb2SumF.Text))
               {
                  sum = Convert.ToInt32(Lb1SumF.Text) + Convert.ToInt32(Lb2SumF.Text);
               }
            
               Lb3.Text = Convert.ToString(sum);
        }
