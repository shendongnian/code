        System.Threading.Thread t = new System.Threading.Thread(() =>
        {
            client.Connect(ip,port );
        });
            t.Start();
        }
