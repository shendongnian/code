        private readonly ATcpState state = new ATcpState();
        private void Receive()
        {
            // create the callback here, in order to use in dynamic
            AsyncCallback ReceiveCallback = delegate(IAsyncResult ar)
                {
                    try
                    {
                        // Read data from the remote device.
                        state.BytesReceived = state.Socket.EndReceive(ar);
                    }
                    catch (Exception e)
                    {
                        // ...
                    }
                };
            try
            {
                    state.Socket.BeginReceive(state.Buffer, 0, state.BufferSize, 0,
                        ReceiveCallback, null);
            }
            catch (Exception e)
            {
                // ...
                // ...
            }
        }
