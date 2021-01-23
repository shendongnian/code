        public void Disconnect()
        {
            try
            {
                connectedSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception)
            {
                // Ignore the exception. The client probably already disconnected.
            }
            connectedSocket.Dispose(); // This is safe; a double dispose will simply be ignored.
        }
