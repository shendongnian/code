    private void AutoPurchaseVouNo1()
        {
            try
            {
                int Num = 0;
                con.Close();
                con.Open();
                string incre = "SELECT MAX(VoucherNoint+1) FROM tbl_PurchaseAllCompany";
                SqlCommand command = new SqlCommand(incre, con);
                if (Convert.IsDBNull(command.ExecuteScalar()))
                {
                    Num = 100;
                    txtVoucherNoInt1.Text = Convert.ToString(Num);
                    txtVoucherNo1.Text = Convert.ToString("ABC" + Num);
                }
                else
                {
                    Num = (int)(command.ExecuteScalar());
                    txtVoucherNoInt1.Text = Convert.ToString(Num);
                    txtVoucherNo1.Text = Convert.ToString("ABC" + Num);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
