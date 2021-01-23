    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                CreateData();
                this.DataContext = Data;
            }
            
        public DataSet Data { get; set; }
        private void CreateData()
        {
            Data = new DataSet();
            Data.Tables.Add(CreateJobTable());
            Data.Tables.Add(CreateSessionsTable());
            Data.Tables.Add(CreateBreaks());
            DataRelation relation = GetJobSessionRelations();
            DataRelation relation2 = GetSessionBreakRelations();
            Data.Relations.AddRange(new[] {relation, relation2});
        }
        private DataTable CreateJobTable()
        {
            var jobs = new DataTable();
            jobs.TableName = "JobDetails";
            var col1 = new DataColumn("ID");
            var col2 = new DataColumn("Title");
            var col3 = new DataColumn("Description");
            col1.DataType = Type.GetType("System.Int32");
            col2.DataType = Type.GetType("System.String");
            col3.DataType = Type.GetType("System.String");
            jobs.Columns.Add(col1);
            jobs.Columns.Add(col2);
            jobs.Columns.Add(col3);
            DataRow row = jobs.NewRow();
            row["ID"] = 1;
            row["Title"] = "Job 1";
            row["Description"] = "Job Desc 1";
            jobs.Rows.Add(row);
            DataRow row2 = jobs.NewRow();
            row2["ID"] = 2;
            row2["Title"] = "Job 2";
            row2["Description"] = "Job Desc 2";
            jobs.Rows.Add(row2);
            return jobs;
        }
        private DataTable CreateSessionsTable()
        {
            var sessions = new DataTable();
            sessions.TableName = "SessionDetails";
            var col1 = new DataColumn("ID");
            var col2 = new DataColumn("Title");
            var col3 = new DataColumn("Description");
            var col4 = new DataColumn("JobID");
            col1.DataType = Type.GetType("System.Int32");
            col2.DataType = Type.GetType("System.String");
            col3.DataType = Type.GetType("System.String");
            col4.DataType = Type.GetType("System.Int32");
            sessions.Columns.Add(col1);
            sessions.Columns.Add(col2);
            sessions.Columns.Add(col3);
            sessions.Columns.Add(col4);
            DataRow row = sessions.NewRow();
            row["ID"] = 1;
            row["Title"] = "Session 1";
            row["Description"] = "Session Desc 1";
            row["JobID"] = 1;
            sessions.Rows.Add(row);
            DataRow row2 = sessions.NewRow();
            row2["ID"] = 2;
            row2["Title"] = "Session 2";
            row2["Description"] = "Session Desc 2";
            row2["JobID"] = 1;
            sessions.Rows.Add(row2);
            DataRow row3 = sessions.NewRow();
            row3["ID"] = 3;
            row3["Title"] = "Session 3";
            row3["Description"] = "Session Desc 3";
            row3["JobID"] = 2;
            sessions.Rows.Add(row3);
            DataRow row4 = sessions.NewRow();
            row4["ID"] = 4;
            row4["Title"] = "Session 4";
            row4["Description"] = "Session Desc 4";
            row4["JobID"] = 2;
            sessions.Rows.Add(row4);
            return sessions;
        }
        private DataTable CreateBreaks()
        {
            var breaks = new DataTable();
            breaks.TableName = "BreakDetails";
            var col1 = new DataColumn("ID");
            var col2 = new DataColumn("Title");
            var col3 = new DataColumn("Description");
            var col4 = new DataColumn("SessionID");
            col1.DataType = Type.GetType("System.Int32");
            col2.DataType = Type.GetType("System.String");
            col3.DataType = Type.GetType("System.String");
            col4.DataType = Type.GetType("System.Int32");
            breaks.Columns.Add(col1);
            breaks.Columns.Add(col2);
            breaks.Columns.Add(col3);
            breaks.Columns.Add(col4);
            DataRow row = breaks.NewRow();
            row["ID"] = 1;
            row["Title"] = "Break 1";
            row["Description"] = "Break Desc 1";
            row["SessionID"] = 1;
            breaks.Rows.Add(row);
            DataRow row2 = breaks.NewRow();
            row2["ID"] = 2;
            row2["Title"] = "Break 2";
            row2["Description"] = "Break Desc 2";
            row2["SessionID"] = 2;
            breaks.Rows.Add(row2);
            DataRow row3 = breaks.NewRow();
            row3["ID"] = 3;
            row3["Title"] = "Break 3";
            row3["Description"] = "Break Desc 3";
            row3["SessionID"] = 3;
            breaks.Rows.Add(row3);
            DataRow row4 = breaks.NewRow();
            row4["ID"] = 4;
            row4["Title"] = "Break 4";
            row4["Description"] = "Break Desc 4";
            row4["SessionID"] = 4;
            breaks.Rows.Add(row4);
            return breaks;
        }
        private DataRelation GetSessionBreakRelations()
        {
            return new DataRelation("relJobDetailsSessionDetails", Data.Tables["JobDetails"].Columns["ID"],
                                    Data.Tables["SessionDetails"].Columns["JobID"]);
        }
        private DataRelation GetJobSessionRelations()
        {
            var dataRelation = new DataRelation("relSessionDetailsBreakDetails", Data.Tables["SessionDetails"].Columns["ID"],
                                                Data.Tables["BreakDetails"].Columns["SessionID"]);
            return dataRelation;
        }
        private void lstJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void lstSessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void lstBreaks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        }
    }
