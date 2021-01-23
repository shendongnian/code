    public void FillMaxBankCode()
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds = bol.SelectMaxBankCode();
                    string j = ds.Tables[0].Rows[0].ToString();
                    txtbankid.Text = j;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
