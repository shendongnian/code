    public string[]ParseCommands(string txtS)
    {
        char[] delimiterChars = { ';' };
    
        string text = txtS;
        System.Console.WriteLine($"Original text: '{text}'");
    
        string[] words = text.Split(delimiterChars);
        System.Console.WriteLine($"{words.Length} words in text:");
        return words;
    }
    private void cmdSend_Click(object sender, EventArgs e)
    {
        string txtS, lastMsg;
        txtS = txtSend.Text;
    
        string[] commands = ParseCommands(txtS);     
    
    	foreach (var element in commands)
    	{		
            byte[] bySend = Encoding.Default.GetBytes(element);
            byte[] byReceive = new byte[255];
            elfinSocket.Send(bySend, 0, txtS.Length, 0);
            int intReceive = elfinSocket.Receive(byReceive, 0, byReceive.Length, 0);
            Array.Resize(ref byReceive, intReceive);
            lastMsg = Encoding.Default.GetString(byReceive);
            lblRecieve.Text = lastMsg;
    	}
    }
