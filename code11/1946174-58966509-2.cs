    using System;
    using System.Collections.Generic;
    using System.Timers;
    using System.Windows.Forms;
    using System.Windows.Threading;
    namespace DataGrid
    {
    public partial class Form1 : Form
    {
        
        List<MyDataModel> myDataModels = new List<MyDataModel>();
        public Form1()
        {
            InitializeComponent();
            // Read csv data at the begining
            ReadCSVData();
            // Set data in the grid
            dataGridView1.DataSource = myDataModels;
            // Then read the data file in regular interval and set in the grid
            StartAutoRefresh();
        }
        private void ReadCSVData()
        {
            CSVReader cSVReader = new CSVReader();
            var newCSVDataRows = cSVReader.GetNewCSVValue();
            if (newCSVDataRows != null)
            {
                myDataModels.AddRange(newCSVDataRows);
            }            
        }
        #region Timer 
        private static System.Timers.Timer _timer;
        private void StartAutoRefresh()
        {
            Console.WriteLine("Start the Datafetch " + DateTime.Now);
            if (_timer == null)
            {
                int dataFetchInterval = 1;
                dataFetchInterval = dataFetchInterval * 60 * 1000;
                _timer = new System.Timers.Timer(dataFetchInterval);
                _timer.Elapsed += new 
        ElapsedEventHandler(FetchTripsOfTheWeek);
                _timer.Interval = dataFetchInterval;
                _timer.Enabled = true;
            }
            else
            {
                _timer.Enabled = true;
            }
        }
        public void StopAutoRefresh()
        {
            if (_timer != null)
            {
                _timer.Enabled = false;
                _timer.Dispose();
                _timer = null;
            }
        }
        public void FetchTripsOfTheWeek(object source, ElapsedEventArgs e)
        {
            bool isResourcesLoaded = false;
            executeActionOnBackgroundThread(
               "Loading data ...",
               () =>
               {
                   try
                   {
                       ReadCSVData();
                       isResourcesLoaded = true;
                   }
                   catch (Exception exception)
                   {
                       var message = exception.Message;
                       MessageBox.Show(message);
                       isResourcesLoaded = false;
                   }
               },
               () =>
               {
                   var result = true;
                   if (isResourcesLoaded)
                   {
                       // Set data in the grid
                       dataGridView1.DataSource = null;
                       dataGridView1.DataSource = myDataModels;
                       dataGridView1.Refresh();
                   }
                   return result;
               },
               () =>
               {
                   // Do extra things, like, setting readonly mode etc
               });
        }
        private void executeActionOnBackgroundThread(string indicatorMessage, 
        System.Action backgroundAction, System.Func<bool> uiAction, 
       System.ActiononCompletedAction = null)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                backgroundAction?.Invoke();
                
                BeginInvoke(new System.Action(() =>
                {
                    var success = uiAction?.Invoke();
                    onCompletedAction?.Invoke();
                }), null);
            });
        }
        #endregion
    }
