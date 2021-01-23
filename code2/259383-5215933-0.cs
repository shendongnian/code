    private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar.Equals(Convert.ToChar(13)))
                {
                    btnLogin_Click(sender, e);
                }
            } 
