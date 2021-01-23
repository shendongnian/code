    process.OutputDataReceived +=
       (sender, e) =>
       {
            string stringResults = e.Data;
            // do some work on stringResults...
            results = stringResults;
       }
    // or
    process.OutputDataReceived +=
       delegate(object sender, DataReceivedEventArgs e)
       {
            string stringResults = e.Data;
            // do some work on stringResults...
            results = stringResults;
       }
