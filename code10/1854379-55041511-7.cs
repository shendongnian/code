    public partial class Form1 : AsyncBaseDialog
    {
            private IDisposable CIP3Subscription = null;
            static System.Windows.Forms.Timer timer1; //The timer is used but just for visual purposes - nothing is related to him
            IObservable<FileSystemEventArgs> TIFFFilesCreated;
            IObservable<FileSystemEventArgs[]> TIFFGroupFiles;
            IObservable<FileSystemEventArgs> CIP3FilesCreated;
            IObservable<FileSystemEventArgs[]> CIP3GroupFiles;
    		bool currStatus = (bool)Properties.Settings.Default["TIFFtoXML_EnabledConversion"]; //If the enable conversion checkbox is enabled, fire the observable
                if(currStatus)
                {
                    EnableTIFFtoXMLWatcher(currStatus); 
                    EnableCIP3toTIFFWatcher(currStatus);
                }
    			timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(SecondElapsed);
                timer1.Enabled = currStatus;
                counter = Convert.ToInt32(Properties.Settings.Default.TIFFtoXML_MainTimer);
    }        
     #region timerStuff
            DateTime start;
            double s;
            private void CountDown()
            {
                start = DateTime.Now;
                s = (double)counter;        
                timer1.Start();
            }
            private void SecondElapsed(object sender, EventArgs e)
            {
                double remainingSeconds = s - (DateTime.Now - start).TotalSeconds;
                if (remainingSeconds <= 0)
                {
                    timer1.Stop();
                    timer1.Interval = (int)counter;
                    timer1.Start();
                    CountDown();
                }
                var x = TimeSpan.FromSeconds(remainingSeconds);
                tb_MainTimer.Text = x.Seconds.ToString();
            }
            #endregion
    		#region ObservableMethods //Methods i built in order to handle the observable behaviour
            private IObservable<FileSystemEventArgs[]> CreateObjectForConvertAll(string inputFolder, string extension)
            {            
    		//I've a checkbox where the user selects "Convert all", and it will convert everything in the folder. Since i didn't wanted to repeat
    		//code by calling all methods again, this method returns me an object i can query
    		
                List<FileSystemEventArgs> tempList = new List<FileSystemEventArgs>(Directory.GetFiles(tb_TIFFtoXMLInputFolder.Text, extension, SearchOption.TopDirectoryOnly).ToList()
                                .Select(x => new FileSystemEventArgs(WatcherChangeTypes.Created, "", x)));
                List<FileSystemEventArgs[]> fswArgsArrayList = new List<FileSystemEventArgs[]>();           
                fswArgsArrayList.Add(tempList.ToArray());
                var finalObservable = fswArgsArrayList.ToArray();
                var finalObservableNotArray = finalObservable.ToArray().ToObservable();
                return finalObservableNotArray;
            }
            private IObservable<FileSystemEventArgs> CreateReactiveFSWInstance(string inputFolder, string fileFilter, bool checkBoxStatus)
            {
    			//Creates the Reactive FSW instance
    			//checkBoxStatus => Enabled or not ; if the user enables the conversion, EnableRaisingEvents will be true
                IObservable<FileSystemEventArgs> filesCreated =
        Observable
            .Using(
                () =>
                {
                    var fsw = new FileSystemWatcher(inputFolder)
                    {
                        EnableRaisingEvents = checkBoxStatus,
                        Filter = fileFilter
                    };
                    return fsw;
                },
                fsw => Observable.FromEventPattern
                    <FileSystemEventHandler, FileSystemEventArgs>(
                    h => fsw.Created += h,
                    h => fsw.Created -= h))
            .Delay(TimeSpan.FromSeconds(0.1))
            .Select(x => x.EventArgs);
                return filesCreated;
            }        
            private IObservable<FileSystemEventArgs[]> TIFFPublish(IObservable<FileSystemEventArgs> observable)
            {
                var GroupFiles =
                     observable
                         .Publish(fc =>
                             from w in fc.Window(() => fc.Throttle(TimeSpan.FromSeconds((double)counter)))
                             from fcs in w.ToArray()
                             select fcs);
                return GroupFiles;
            }
            #endregion 
    		private void StartCIP3ProcessingQuery(IObservable<FileSystemEventArgs[]> Files)
    		{
    			//query goes here...
    		}
    		 private void StartTIFFProcessingQuery(IObservable<FileSystemEventArgs[]> Files)
            {
    			//query goes here...
    		}
    		private void EnableTIFFtoXMLWatcher(bool status)
            {
    			//Enable the reactive watcher for TIF files
                TIFFFilesCreated = CreateReactiveFSWInstance(tb_TIFFtoXMLInputFolder.Text, "*.tif", status);
                TIFFGroupFiles = TIFFPublish(TIFFFilesCreated);
                StartTIFFProcessingQuery(TIFFGroupFiles);
            }
            private void EnableCIP3toTIFFWatcher(bool status)
            {
    			//Enable the reactive watcher for CIP3 files
                CIP3FilesCreated = CreateReactiveFSWInstance(tb_TIFFtoXMLInputFolder.Text, "*.*", status);
                CIP3GroupFiles = TIFFPublish(CIP3FilesCreated);
                StartCIP3ProcessingQuery(CIP3GroupFiles, false);
            }
            private void SubscriptionDisposal()
            {
                //Disposal methods
                TIFFSubscription.Dispose();
                CIP3Subscription.Dispose();
            }
    		//Enable or disable the conversio, or convert all
    		private void CheckboxChangedEventHandler(object sender, EventArgs e)
            {
                CheckBox CurrChk = sender as CheckBox;
                bool status = CurrChk.Checked;
                switch (CurrChk.Name)
                {
                    case "TIFFtoXML_chkConvertAll":
                        {
                            if(status)
                            {
                               cb_enableTIFFtoXML.Checked = true; //Enabling this checkbox triggers the other case and fires the FSW
                                var convertAllTIFFObj = CreateObjectForConvertAll(tb_TIFFtoXMLInputFolder.Text, "*.tif");
                                StartTIFFProcessingQuery(convertAllTIFFObj);
                                var convertAllCIP3Obj = CreateObjectForConvertAll(tb_TIFFtoXMLInputFolder.Text, "*.*");
                                StartCIP3ProcessingQuery(convertAllCIP3Obj,true);                            
                                CurrChk.Checked = false;
                            }        
                            break;
                        }
                    case "cb_enableTIFFtoXML":
                        {
                            if (status)
                            {
                                EnableCIP3toTIFFWatcher(status);
                                EnableTIFFtoXMLWatcher(status);
                                CountDown();
                            }
                            else
                            {
    							//If the user disables the conversion, it will just dispose objects.
                                TIFFSubscription.Dispose();
                                CIP3Subscription.Dispose();
                                timer1.Stop();
                            }
    
                            break;
                        }
    			}
    		}
    		
