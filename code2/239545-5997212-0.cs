            private void ThreadRx()
            {
    				while (true)
                    {
                        try
                        {
                            if (this._serialPort.IsOpen == true)
                            {
                                int count = this._serialPort.BytesToRead;
                                if (count > 0)
                                {
                                    byte[] Buffer = new Byte[count];
                                    this._serialPort.Read(Buffer, 0, count);
    								
    		                    //To do: Call your reception event (sending the buffer)
                                }
                                else
                                {
                                    Thread.Sleep(50);
                                }
                            }
                            else
                            {
                                Thread.Sleep(200);
                            }
                        }
                        catch (ThreadAbortException ex)
                        {
                            //this exception is invoked calling the Abort method of the thread to finish the thread
                            break;//exit from while
                        }
                        catch (Exception ex)
                        {
                            //To do:call your error event
                        }
                    }
            }
