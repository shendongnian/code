    foreach (string rCode in _config.rCodes) {
        string code = rCode;
        taskList.Add(Task.Factory.StartNew(() =>
        {
            using (TextWriter tw = new StreamWriter(_config.OutputPath + string.Format(@"\{0}-{1}.csv", code, DateTime.Now.ToString("yyyy-MM-ddHHmmssfff")), false)) {
                // ...
            }
        }
    }
