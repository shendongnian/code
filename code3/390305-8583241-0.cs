            // Start the listener
            tcpListener_ = new TcpListener(ipAddress[0], int.Parse(portNumber_));
            tcpListener_.Start();
            try
            {
                // Wait for client connection
                while (true)
                {
                    // Wait for the new connection from the client
                    if (tcpListener_.Pending())
                    {
                        socket_ = tcpListener_.AcceptSocket();
                        changeState(InstrumentState.Connected);
                        readSocket();
                    }
                    Thread.Sleep(1);
                }
            }
            catch (ThreadInterruptedException) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contineo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
