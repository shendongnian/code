        private void Form1_Load(object sender, EventArgs e)
        {
            txtSummary.Text = "0";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToTextBox(1);
        }
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            AddToTextBox(-1);
        }
        private void AddToTextBox(int changeBy)
        {
            int value;
            if(int.TryParse(txtSummary.Text, out value))
            {
                value = value + changeBy;
                txtSummary.Text = value.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Integer in TextBox!");
            }
        }
