                using(NetworkStream ns = new NetworkStream(ShittySocket.Client, false))
    {
                using(StreamReader sr = new StreamReader(ns))
                {
                    XmlDocument xdoc = new XmlDocument();
                    while(xdoc != null)
                    {
                        xdoc = Program.GrabXmlDocFromStream(sr);
                        if(xdoc != null)
                            Program.Handle_Document(xdoc);
                    }
                }
    }
