         private void btnCopytoBAN_Click(object sender, EventArgs e)
        {
            if (BAddress.Text.Length == 0)
                BAddress.Text = MAddress.Text;
            if (BCity.Text.Length == 0)
                BCity.Text = MCity.Text;
            if (BState.Text.Length == 0)
                BState.Text = MState.Text;
            if (BZIP.Text.Length == 0)
                BZIP.Text = MZIP.Text;
            if (BEmail.Text.Length == 0)
                BEmail.Text = MEmail.Text;
            if (BName.Text.Length == 0)
                BName.Text = MFName.Text + " " + MLName.Text;
            if (TEmail.Text.Length == 0)
                TEmail.Text = MEmail.Text;
            if (TName.Text.Length == 0)
                TName.Text = MFName.Text + " " + MLName.Text;
            if (BPhone.Text.Length == 0)
            {
                BPhone.Text = MWork.Text;
                if (BPhone.Text.Length == 0)
                    BPhone.Text = MMobile.Text;
                if (BPhone.Text.Length == 0)
                    BPhone.Text = MHome.Text;
            }
            if (TPhone.Text.Length == 0)
            {
                TPhone.Text = MWork.Text;
                if (TPhone.Text.Length == 0)
                    TPhone.Text = MMobile.Text;
                if (TPhone.Text.Length == 0)
                    TPhone.Text = MHome.Text;
            }
        }
