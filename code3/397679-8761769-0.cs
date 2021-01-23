    var shouldExit == false;
    while (!shouldExit)
        using (TcpClient c = listener.AcceptTcpClient())
        {
            using (NetworkStream n = c.GetStream())
            {
                string msg = new BinaryReader(n).ReadString();
                if (msg == "exit")
                    // Client told us to exit...
                    shouldExit = true;
                BinaryWriter w = new BinaryWriter(n);
                w.Write(msg + " back atcha!");
                w.Flush(); // Must call Flush because we're not disposing the writer.
            }
            client.Close();
        }
