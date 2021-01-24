    private async void ReadTheSerialData()
    {
         var buffer = new byte[200];
         while (serialPort.IsOpen) {
             var valid = await serialPort.BaseStream.ReadAsync(buffer, 0, buffer.Length);
             for (int i = 0; i < valid; ++i)
             {
                 //Parse data
                double[] samplesAtTimeT = DataParserObj.interpretBinaryStream(buffer[i]);
                //Add data to BlockingCollection when parsed 
                if (samplesAtTimeT != null)
                    _bqBufferTimerSeriesData.Add(samplesAtTimeT);
             }
         }
    }
