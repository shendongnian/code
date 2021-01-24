    var output = ServerLogic.Logic.Execute(input, db_path);
    var length = BitConverter.GetBytes(output.Length); // You again need to get the length
    pinger.Done = true;
    lock (pinger._lock)
    {
       bw.Write(length); // Send it before the data
       bw.Write(output);
       bw.Flush();
    }
