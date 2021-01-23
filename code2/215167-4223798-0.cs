          byte[] bufferRec;
                while (client.Available != 0)
                {
                    Thread.Sleep(10);
                }
            client.Receive(bufferRec);  
    string response=Encoding.ASCII.GetString(bufferRec);
    var list= response.Split('\n');
