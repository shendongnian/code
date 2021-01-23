       BackgroundWorker = new BackgroundWorker();
       worker.DoWork += Worker_DoWork;
       worker.WorkerReportsProgress = true;
       worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
       private void Worker_DoWork(object sender, DoWorkEventArgs e)
       {
            BackgrounderWorker worker = (BackgroundWorker)sender;
            //Query the database
            //Instantiate a custom-class to contain the results
            IList<Users> users = userRepository.SelectAll();
            QueryResults results = new QueryResults(users);
            worker.ReportProgress(0, results);
       }
       
       //Back In the UI Layer
       private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
           var result = (QueryResult)e.UserState;
           comboBoxUsers.DataSource = result.Users;
           comboBoxUsers.ValueMember = "UserId";
           comboBoxUsers.DisplayMember = "Name";
       }
