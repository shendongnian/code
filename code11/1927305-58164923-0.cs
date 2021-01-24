    private void button1_Click(object sender, EventArgs e)
        {
            AkontoService.AkontasSoapClient client = new AkontoService.AkontasSoapClient();
            var respons = client.GetAkontasById(txtAkonto.Text);
            if (string.IsNullOrEmpty(respons))
            {
                txtRezultat.Text = "Error: Client not found!";
            }
            else
            {
                txtRezultat.Text = respons;
            }
        }
