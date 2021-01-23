            connection();
            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "membershipsample";
            //Mapping Table column    
            objbulk.ColumnMappings.Add("GPO_NAME", "GPO_NAME");
            objbulk.ColumnMappings.Add("Ship_To", "Ship_To");
            objbulk.ColumnMappings.Add("Location_Type", "Location_Type");
            objbulk.ColumnMappings.Add("Bill_To", "Bill_To");
            objbulk.ColumnMappings.Add("GPO_CUST_ID", "GPO_CUST_ID");
            objbulk.ColumnMappings.Add("PRI_AFL_FLG", "PRI_AFL_FLG");
            objbulk.ColumnMappings.Add("MCK_GPO_PGM_TYPE", "MCK_GPO_PGM_TYPE");
            objbulk.ColumnMappings.Add("MCK_GPO_PGM_SUB_TYPE", "MCK_GPO_PGM_SUB_TYPE");
            objbulk.ColumnMappings.Add("MCK_MBRSH_EFF_DT", "MCK_MBRSH_EFF_DT");
            objbulk.ColumnMappings.Add("CUST_MAILING_NAME", "CUST_MAILING_NAME");
            objbulk.ColumnMappings.Add("ADDRESS1", "ADDRESS1");
            objbulk.ColumnMappings.Add("ADDRESS2", "ADDRESS2");
            objbulk.ColumnMappings.Add("CITY", "CITY");
            objbulk.ColumnMappings.Add("STATES", "STATES");
            objbulk.ColumnMappings.Add("POSTAL_CODE", "POSTAL_CODE");
            objbulk.ColumnMappings.Add("ACCT_MGR_NAME", "ACCT_MGR_NAME");
            con.Open();
            objbulk.WriteToServer(csvdt);
            con.Close();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files (*.cvs)|*.csv|Excel Files (*.xlsx)|*.xlsx";
            // dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            //dlg.Filter = "CSV Files (*.csv)";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                textBox.Text = filename;
                // readCSV(filename);
            }
        }
        private void readCSV(string Path)
        {
            using (var reader = new StreamReader(Path))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (!String.IsNullOrEmpty(values[0]))
                        listA.Add(values[0]);
                    if (values.Length > 2 && !String.IsNullOrEmpty(values[1]))
                        listB.Add(values[1]);
                }
            }
        }
        private void Bk_DoWork(object sender, DoWorkEventArgs e)
        {
            
            // txtStatus.Visibility = System.Windows.Visibility.Visible;
            DispatcherTimer timer = new DispatcherTimer();
            //Creating object of datatable  
            DataTable tblcsv = new DataTable();
            //creating columns  
            tblcsv.Columns.Add("GPO_NAME");
            tblcsv.Columns.Add("Ship_To");
            tblcsv.Columns.Add("Location_Type");
            tblcsv.Columns.Add("Bill_To");
            tblcsv.Columns.Add("GPO_CUST_ID");
            tblcsv.Columns.Add("PRI_AFL_FLG");
            tblcsv.Columns.Add("MCK_GPO_PGM_TYPE");
            tblcsv.Columns.Add("MCK_GPO_PGM_SUB_TYPE");
            tblcsv.Columns.Add("MCK_MBRSH_EFF_DT");
            tblcsv.Columns.Add("CUST_MAILING_NAME");
            tblcsv.Columns.Add("ADDRESS1");
            tblcsv.Columns.Add("ADDRESS2");
            tblcsv.Columns.Add("CITY");
            tblcsv.Columns.Add("STATES");
            tblcsv.Columns.Add("POSTAL_CODE");
            tblcsv.Columns.Add("ACCT_MGR_NAME");
            // DispatcherTimer timer = new DispatcherTimer();
            string url=string.Empty;
            this.Dispatcher.Invoke(() => { url = textBox.Text; });
            string ReadCSV = File.ReadAllText(url);
            //spliting row after new line  url
            int i = 0;
            DataTable dt = GetMemberTable();
            var worker = sender as BackgroundWorker;
            int rows = ReadCSV.Split('\n').Length / 100;
            int totalRows = ReadCSV.Split('\n').Length;
            foreach (string csvRow in ReadCSV.Split('\n'))
            {
                i++;
               // Thread.Sleep(1000);
                       worker.ReportProgress((i/rows + 1), string.Format("This is new one"));
                this.Dispatcher.Invoke(() => { label.Content = i + " rows have been added or updated"; });
                bool Check = (csvRow.Length > 0) ? Exist(csvRow.Split(',')[1].ToString(), dt) : true;
                if (i > 1 && !string.IsNullOrEmpty(csvRow))
                {
                    //Adding each row into datatable  
                    int count = 0;
                    if (!Check)
                    {
                        tblcsv.Rows.Add();
                        foreach (string FileRec in csvRow.Split(','))
                        {
                            if (count >= 15)
                            {
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                            }
                            else
                            {
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                                count++;
                            }
                            //                  //Calling insert Functions 
                            //                  Dispatcher.Invoke(
                            //new System.Action(() => downloadProgress.Value = i)
                            //);
                            
                        }
                       
                    }
                   
                }
            }
            if (tblcsv.Rows.Count > 0)
            {
                InsertCSVRecords(tblcsv);
            }
            worker.ReportProgress(100, "Done");
            this.Dispatcher.Invoke(() => { textBox.Text = string.Empty; });
            //textBox.Text = string.Empty;
            this.Dispatcher.Invoke(()=> { label.Content = totalRows + " rows have been added or updated"; });
            this.Dispatcher.Invoke(() => { button1.IsEnabled = false; });
            //button1.IsEnabled = false;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bk = new BackgroundWorker();
            bk.RunWorkerCompleted += Bk_RunWorkerCompleted;
            bk.WorkerReportsProgress = true;
            bk.DoWork += Bk_DoWork;
            bk.ProgressChanged += Bk_ProgressChanged;
            bk.RunWorkerAsync();
            
        }
        private void Bk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() => { downloadProgress.Value = e.ProgressPercentage; });
            //downloadProgress.Value = e.ProgressPercentage;
        }
        //private void Bk_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    AddData();
        //    var worker = sender as BackgroundWorker;
        //    worker.ReportProgress(0, string.Format("This is new one"));
        //    for(int i=0;i<10;i++)
        //    {
        //        Thread.Sleep(1000);
        //        worker.ReportProgress((i + 1) * 10, string.Format("This is new one"));
        //    }
            
        //    worker.ReportProgress(100, "Done");
            
        //}
        private void Bk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("All Done");
            this.Dispatcher.Invoke(() => { downloadProgress.Value = 0; });
        }
