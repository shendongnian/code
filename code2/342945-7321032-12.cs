    foreach (string enc in encs)
    {
        try {
            Encoding.GetEncoding(enc);
        } catch {
            Console.WriteLine("Missing {0}", enc);
        }
    }
