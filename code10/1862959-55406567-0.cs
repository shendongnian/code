csharp
 private void Listener_OnNewConnectionReceived(object sender, RequestReceivedEventArgs e)
 {
            string hostname = HttpQueryParser.GetHostName(e.Request);
            NetworkStream proxyClientStream = e.User.GetStream();
            try
            {
                if (firewall.CheckIfBlocked(hostname))
                {
                    //send error page
                    e.User.GetStream().Write(Encoding.ASCII.GetBytes("<html><body style=\"padding:0; margin:0;\"><img style=\"padding:0; margin:0; width:100%; height:100%;\" src=\"https://www.hostinger.co.id/tutorial/wp-content/uploads/sites/11/2017/08/what-is-403-forbidden-error-and-how-to-fix-it.jpg\"</body></html>"));
                    return;
                }
                var targetServer = new TcpClient(hostname, 80);
                NetworkStream targetServerStream = targetServer.GetStream();
                targetServerStream.Write(e.Request);
                var responseBuffer = new byte[32];
                //this is to capture status of http request and log it.
                targetServerStream.Read(responseBuffer, 0, responseBuffer.Length);
                proxyClientStream.Write(responseBuffer, 0, responseBuffer.Length);
                var headers = Encoding.UTF8.GetString(responseBuffer).Split("\r\n");
                logger.Log(new HttpRequestEntry()
                {
                    ResponseCode = headers[0].Substring(headers[0].IndexOf(" ") + 1),
                    Hostname = hostname
                });
                targetServerStream.CopyTo(proxyClientStream);
                    
            }
            catch { return; }
            finally { proxyClientStream.Dispose(); }
           
}
