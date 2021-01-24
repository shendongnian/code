    private async void cmdSend_Click(object sender, EventArgs e)
    {
        string txtS, lastMsg;
        txtS = txtSend.Text;
    
        string[] commands = ParseCommands(txtS);     
    
    	foreach (var element in commands)
    	{	
            string response = await Task.Run(()=>
            {	
                byte[] bySend = Encoding.Default.GetBytes(element);
                byte[] byReceive = new byte[255];
                elfinSocket.Send(bySend, 0, txtS.Length, 0);
                int intReceive = elfinSocket.Receive(byReceive, 0, byReceive.Length, 0);
                Array.Resize(ref byReceive, intReceive);
                return Encoding.Default.GetString(byReceive);
            }
            lblRecieve.Text = response;
    	}
    }
