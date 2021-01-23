        private void SendSAEA_Completed(object sender, SocketAsyncEventArgs sendSAEA)
        {        
                if (sendSAEA.BytesTransferred == 0 || sendSAEA.SocketError != SocketError.Success)
                {
                    Close();
                }
                else
                {
                     // Process sendSAEA.BytesTransferred
                }
         }
