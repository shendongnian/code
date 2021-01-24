    private void btnCAdd_Click(object sender, EventArgs e)
        {           
            string filterConfig = "Add-ContentFilterPhrase";
            string param = $"-Influence";
            string wordchoice = cbCContent.SelectedItem.ToString();
            string ext = $"-Phrase";
            string InputStr = txtPhrase.Text;
            txtCOutput.Text = "Word " + txtPhrase.Text + " added to " + txtGServer.Text;
            
            ContentFilterConfig(filterConfig, param, wordchoice, ext, InputStr);
        }
