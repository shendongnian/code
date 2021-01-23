        private void ReadCallBack(IAsyncResult result)
        {
            ReadStateObject stateObject = (ReadStateObject)result.AsyncState;
            NetworkStream myNetworkStream = stateObject.Stream;
            int numberofbytesread = 0;
            StringBuilder sb = new StringBuilder();
            numberofbytesread = myNetworkStream.EndRead(result);
            sb.Append(Encoding.ASCII.GetString(stateObject.ReadBuffer, 0, numberofbytesread));
            /*It seems, if there is no delay, the DataAvailable may not be true even when there are still data to be received from the site, so I added this delay. Any suggestions, how to avoid this are welcome*/
            Thread.Sleep(500);
                while (myNetworkStream.DataAvailable)
                {
                    byte[] mydata = new byte[1024];
                    numberofbytesread = myNetworkStream.Read(mydata, 0, mydata.Length);
                    sb.Append(Encoding.ASCII.GetString(mydata, 0, numberofbytesread)); 
                }
          Console.Writeln(sb.ToString());
            mytcpclient.Close();
        }
