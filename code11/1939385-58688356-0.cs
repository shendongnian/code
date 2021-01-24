            private void calculateButton_Click(object sender, EventArgs e)
        {
            int days;
            double medication;
            double surgery = 0;
            double labs = 0;
            double rehab = 0;
            if (!int.TryParse(numDaysInHosp.Text, out days) || days == 0)
            {
                MessageBox.Show("Days In Hospital must be greater than zero.");
                numDaysInHosp.Focus();
            }
            else if (!double.TryParse(medsCharges.Text, out medication))
            {
                MessageBox.Show("Charges for Medication cannot be blank.");
                medsCharges.Focus();
            }
            else if (!double.TryParse(surgCharges.Text, out surgery))
            {
                MessageBox.Show("Surgical Charges cannot be blank.");
                surgCharges.Focus();
            }
            else if (!double.TryParse(labFees.Text, out labs))
            {
                MessageBox.Show("Lab Fees cannot be blank.");
                labFees.Focus();
            }
            else if (!double.TryParse(rehabCharges.Text, out rehab))
            {
                MessageBox.Show("Rehabilitation Charges cannot be blank.");
                rehabCharges.Focus();
            }
            else
            {
                MessageBox.Show("Everything is ok");
                //double dayChrgs = CalcDayChrgs(days);
                //double miscChrgs = CalcMiscChrgs(medication, surgery, labs, rehab);
                //double totlCost = CalcTotlChrgs(dayChrgs, miscChrgs);
                //stayChrgsLabel.Text = dayChrgs.ToString("c");
                //miscChrgsLabel.Text = miscChrgs.ToString("c");
                //totlCostLabel.Text = totlCost.ToString("c");
                //memberLevelLabel.Text = memberLevelLabel.ToString();
            }
        }
