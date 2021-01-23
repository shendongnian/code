    private async void ButtonSubmit_Click(object sender, EventArgs e) {
    
            ButtonReset.Enabled = false;
            TextResponse.Text = String.Empty;
            TextResponse.Text += "Begining..." + Environment.NewLine;
    
            TextResponse.Text += await PostSomeData();
            TextResponse.Text += Environment.NewLine;
            TextResponse.Text += "Function Done!" + Environment.NewLine;
            
    }
