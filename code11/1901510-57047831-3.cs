    private void sendData()
    {
    	Console.WriteLine("sending");
    	string Seuil = SeuilVal.Text + '\0';  // Text plus NULL terminator.
    	ComPort.Write(Seuil);                 // Send the user's text plus NULL terminator straight out the port.
    	Console.WriteLine(Seuil);
    	//SeuilVal.Clear();                     // Clear screen after sending data.
    }
