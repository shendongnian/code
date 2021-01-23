        protected void getResults(ISiemsen siemens ... ) 
         {
           SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
           int iRx = theSockId.m_currentSocket.EndReceive(asyn);
           char[] chars = new char[iRx + 1];
           Decoder decode = Encoding.Default.GetDecoder();
           int charLength = decode.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
           String szData = new String(chars);
           WaitForData();
        //Handle Message here
           siemsen.ShowTheResult(theResult);
         }
