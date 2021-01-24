    // Reading thread
    lock (q)
    {
        q.Enqueue(line_list);
    }
    // Processing thread
    while (true)
    {
        List<byte> list;
        lock (q)
        {
            if (q.Count == 0) break;
            list = new List<byte>(q.Dequeue());
        }
        string line_str = DecodeBytes(list); // Decoding
        // ...
