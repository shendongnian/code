        private async void button1_Click(object sender, EventArgs e)
        {
            Inetlab.SMPP.SmppClient client = new Inetlab.SMPP.SmppClient();
            await client.Connect("x.x.x.x", y);
            await client.Bind("systemid", "password", ConnectionMode.Transceiver);
            var resp = await client.Submit(
               SMS.ForSubmit()
                   .From("SOURCEADDR", AddressTON.Alphanumeric, AddressNPI.Unknown )
                   .To("mobilenumber", AddressTON.International, AddressNPI.ISDN)
                   .Coding(DataCodings.Default)
                   .Text("test text")
               );
            if (resp.All(x => x.Header.Status == CommandStatus.ESME_ROK))
            {
                MessageBox.Show("Message has been sent.");
            }
            else
            {
                MessageBox.Show(resp.GetValue(0).ToString());
            }
        }
