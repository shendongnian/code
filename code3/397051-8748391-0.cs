    void GenerateReports()
    {
    var backgroundWorker = new BackgroundWorker();
    backgroundWorker.DoWork += ((s, e) =>
        {
            // time consuming function
            foreach (var employee in employees)
                GenerateReport(employee);
        }); 
    backgroundWorker.RunWorkerCompleted += ((s, e) =>
        {
            //do something
        });
    backgroundWorker.RunWorkerAsync();
    } 
    delegate void Update(Employee employee);
    static void GenerateReport(Employee employee)
    {
        if (this.InvokeRequired)
        {
            Update = new Update(GenerateReport);
            this.Invoke(updaterDelegate, new object[] { employee });
        }
        else
            GenerateReport(employee)
    }
