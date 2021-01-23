    foreach (var i in args) {
        new Thread(delegate {
            try { OpenFile(i); }
            catch (Exception e) { Console.WriteLine("Error processing file {0}: {1}",
                                                    i, e.ToString()); }
        }).Start();
    }
