        private void Completed(object sender, SocketAsyncEventArgs e)
        {
            // What type of operation did just completed?
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Send:
                    {
                        ProcessSent(e);
                        break;
                    }
            }
        }
