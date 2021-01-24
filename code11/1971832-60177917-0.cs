    public void beginListenForData()
        {
            try
            {
                inStream = btSocket.InputStream;
                streamReader = new StreamReader(inStream);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            char[] buffer = new char[256];
            string[] buf = new string[2];
            int bytes;
            while (1)
            {
                try
                {
                    if ((bytes = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string tekst = new string(buffer, 0, bytes);
                        if(buf[0] == null)
                        {
                            buf[0] = tekst;
                        }
                        else
                        {
                            buf[1] = tekst; 
                        }
                        string eindtekst = string.Join("", buf);
                        if (eindtekst == "D0O")
                        {
                            System.Diagnostics.Debug.WriteLine("Vergelijking gelukt!");
                            System.Diagnostics.Debug.WriteLine(eindtekst);
                            Array.Clear(buffer, 0, buffer.Length);
                            Array.Clear(buf, 0, buf.Length);
                            writeData("D2O");
                        }
                        streamReader.DiscardBufferedData();
                        
                    }
                }
                catch (Java.IO.IOException)
                {
                    break;
                }
            }
        }
