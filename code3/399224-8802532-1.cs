    var bw = new BackgroundWorker();
    bw.DoWork += (s, e) => {
                             ...
                             x.Add(message);
                             ...
                             e.Result = x;
                           };
    bw.RunWorkerCompleted += (s, e) => MsgDGV.DataSource = e.Result;
    bw.RunWorkerAsync();
