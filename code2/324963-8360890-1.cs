            try
            {
                Response.Write("One");
                string[] host = (txtEmailAddress.Text.Split('@'));
                string hostname = host[1];
                Response.Write(host);
                IPHostEntry IPhst = Dns.Resolve(hostname);
                IPEndPoint endPt = new IPEndPoint(IPhst.AddressList[0], 25);
                Socket s = new Socket(endPt.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
                Response.Write(endPt);
                s.Connect(endPt);
            }
            catch (SocketException se)
            {
                lblErrMsg.Text = se.Message.ToString();
                PublicUtils.AddError("Error: " + se.Message + txtEmailAddress.Text);
                txtEmailAddress.Focus();
                return;
            }  
