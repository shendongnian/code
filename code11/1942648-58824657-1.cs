                        byte[] dataBuffer = new byte[3000000]; // big enough buffer
                        bool singleReadIterationFinished = false;
            			while (!singleReadIterationFinished)
            			{
            				Task<int> bytesReadFromPort = _serialPort.BaseStream.ReadAsync(dataBuffer, bufferOffset, dataBuffer.Length - bufferOffset); // read as many bytes as available at a time
            				
                            //other code can go here since the thread isn't blocked 
            
            				bufferOffset += bytesReadFromPort.Result; // From docs.Microsoft: Calling the result properties get accessor will block the calling thread until the asyncrhonous operation is complete; this is equivalent to calling 'Wait' method.
            				if (bufferOffset > 2000000) // wait for 2megabytes of data. change this to megabytes. 
            				{
            					Console.WriteLine("Read a total of : " + bufferOffset + " Bytes");
            					byte[] copyBuffer = new byte[dataBuffer.Length];
            					Array.Copy(dataBuffer, 0, copyBuffer, 0, dataBuffer.Length);
            					DecodeFileData(copyBuffer, header, trailer); // need to call this asyncronously
            					singleReadIterationFinished = true;
            				}
            			}
