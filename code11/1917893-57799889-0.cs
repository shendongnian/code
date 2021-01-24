     private void Button3_Click(object sender, EventArgs e)
            {
                if (sck.Connected)
                {
                    sck.Shutdown(SocketShutdown.Both);
                    MessageBox.Show(sck.Connected.ToString()); // this is to see if socket is connected.
                }
            }
