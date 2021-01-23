            ReadStateObject stateObject; //Info below
            mytcpclient = new TcpClient();
            mytcpclient.Connect(host, port);
            mysocket = mytcpclient.Client;
            SendHeader(mysocket);//Info below
            ns = mytcpclient.GetStream();
            if (ns.CanRead)
            {
                stateObject = new ReadStateObject(ns, 1024);
                ns.BeginRead(stateObject.ReadBuffer, 0, stateObject.ReadBuffer.Length, new AsyncCallback(ReadCallBack), stateObject);
            }
