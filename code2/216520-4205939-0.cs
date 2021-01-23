    public void connect(string host, int port)
    {
    	try {
    		mobjClient = new TcpClient(host, port);
    		mobjClient.GetStream.BeginRead(marData, 0, 1024, DoRead, null);
    		DisplayText("Connected to " + host + " On port " + port);
    	} catch {
    		MarkAsDisconnected("Connection error.");
    	}
    }
    
    public void Send(string t, bool disp = true)
    {
    	try {
    		System.IO.StreamWriter w = new System.IO.StreamWriter(mobjClient.GetStream);
    		w.Write(t + Strings.Chr(0));
    		w.Flush();
    		if (disp == true) {
    			//DisplayText(t)
    		}
    	} catch {
    		DisplayText("Error Sending!");
    	}
    }
    
    private void DoRead(IAsyncResult ar)
    {
    	int intCount = 0;
    	try {
    		intCount = mobjClient.GetStream.EndRead(ar);
    		if (intCount < 1) {
    			//MarkAsDisconnected("Error reading Stream!")
    			DisplayText("Error reading stream.");
    			//Exit Sub
    		}
    
    		BuildString(marData, 0, intCount);
    
    		mobjClient.GetStream.BeginRead(marData, 0, 1024, DoRead, null);
    	} catch (Exception e) {
    		MarkAsDisconnected("Reconnecting...");
    		connect("xivio.com", 7777);
    		LogIn("lograinbows", "inthesky", "DRESSLOGCASINO");
    	}
    }
    
    //'// This is important!  Keep the Decoder and reuse it when you read this socket.
    //'// If you don't, a char split across two reads will break.
    
    Decoder decoder = Encoding.UTF8.GetDecoder();
    
    
    private void BuildString(byte[] bytes, int offset, int byteCount)
    {
    	try {
    		//'// Here's where the magic happens.  The decoder converts bytes into chars.
    		//'// But it remembers the final byte(s), and doesn't convert them,
    		//'// until they form a complete char.
    		char[] chars = new char[bytes.Length + 1];
    		int charCount = decoder.GetChars(bytes, offset, byteCount, chars, 0);
    
    		for (int i = 0; i <= charCount - 1; i++) {
    			//'// The fix for bullet #2
    			if (chars[i] == Strings.Chr(0)) {
    				mobjText.Append(Constants.vbLf);
    
    				object[] @params = { mobjText.ToString };
    				this.Invoke(new DisplayInvoker(this.HandleXML), @params);
    
    				//'// You don't have to make a new StringBuilder, BTW -- just clear it.
    				mobjText.Length = 0;
    			} else {
    				mobjText.Append(chars[i]);
    			}
    		}
    	} catch (Exception e) {
    		DisplayText("Error: ", e.Message);
    	}
    }
