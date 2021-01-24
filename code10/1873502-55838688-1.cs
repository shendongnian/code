    private void btmDoCalc_Click(object sender, EventArgs e)
        {
            // Here show it up in message box directly.
            MessageBox.Show("DoCalc= " + DoCalc(13, 2, 5).ToString());
            // Here assign it to some double variables.
            double N1 = 0, N2 = 0, N3 = 0;
            N1 = DoCalc(13, 2, 4);
            N2 = DoCalc(13, 2, 3);
            N3 = DoCalc(13, 2, 2);
            MessageBox.Show("DoCalc= " + N1);
            MessageBox.Show("DoCalc= " + N2);
            MessageBox.Show("DoCalc= " + N3);
        }
