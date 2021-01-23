        private void doInput()
        {
            NetworkStream ns = new NetworkStream(ShittySocket.Client, false);
            while (_connected)
            {
                if (ns.DataAvailable)
                {
                    using (StreamReader sr = new StreamReader(ns, System.Text.Encoding.UTF8))
                    {
                            XmlDocument objXmlDocument = new XmlDocument();
                            objXmlDocument.LoadXml(sr.ReadToEnd());
                            onInput(this, objXmlDocument);
                    }
                }
                Thread.Sleep(100);
            }
        }
