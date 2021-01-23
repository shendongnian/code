            // build/fill your Socket-Queue for example in the con
            class SocketExample
            {
            Queue<Socket> a = new Queue<Socket>();
            SocketExample ()
            {
            int ii = 0, C = 256;
            for (ii = 0; ii < C; C++)
            {
                a.Enqueue (new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp));
            }
            }
            //in you function you just dequeue a Socket and use it, after you are finished you enqueue it
             void CheckNetIP (some parameters...)
             {
            Socket S = a.Dequeue();
            // do whatever you want to do...
            // IF there is no exception
            a.Enqueue(S); 
            }
            }
