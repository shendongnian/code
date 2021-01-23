    public partial class FormMain : Form
    {
        private List<Person> _Persons;
        private Random _Random;
        private int _TimeoutBetweenInserts;
        public FormMain()
        {
            InitializeComponent();
            // Initialize our private fields
            _Random = new Random();
            _Persons = new List<Person>();
            _TimeoutBetweenInserts = (int)numericUpDownTimeoutBetweenInserts.Value;
            // Attach the list to the binding source and get informed on list changes.
            personBindingSource.DataSource = _Persons;
            personBindingSource.ListChanged += (sender, e) => labelDataGridViewCount.Text = _Persons.Count.ToString();
        }
        private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var spinner = new SpinWait();
            var worker = (BackgroundWorker)sender;
            // Should we abort our adding?
            while (!worker.CancellationPending)
            {
                // Create a new entry ...
                var person = new Person();
                person.Index = _Persons.Count;
                person.Born = new DateTime(_Random.Next(1950, 2012), _Random.Next(1, 13), _Random.Next(1, 28));
                person.FirstName = "Hello";
                person.LastName = "World";
                // ... and add it to the list
                _Persons.Add(person);
                // Do a little waiting ... (to avoid blowing out the list)
                for (int i = 0; i < _TimeoutBetweenInserts; i++)
                {
                    spinner.SpinOnce();
                }
                spinner.Reset();
            }
        }
        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Stop the gui updater, cause the background worker also stopped.
            timerGuiUpdater.Stop();
        }
        private void OnCheckBoxToggleWorkerCheckedChanged(object sender, EventArgs e)
        {
            // Update the "button" according to the state
            checkBoxToggleWorker.Text = checkBoxToggleWorker.Checked ? "&Pause" : "&Start";
            if (checkBoxToggleWorker.Checked)
            {
                if (!backgroundWorker.IsBusy)
                {
                    // Start the gui updater and the background worker
                    timerGuiUpdater.Start();
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                // Stop the background worker
                backgroundWorker.CancelAsync();
            }
        }
        private void OnNumericUpDownTimeoutBetweenInsertsValueChanged(object sender, EventArgs e)
        {
            // Update the internal value, to let it propagate into the background worker
            _TimeoutBetweenInserts = (int)numericUpDownTimeoutBetweenInserts.Value;
        }
        private void OnTimerGuiUpdaterTick(object sender, EventArgs e)
        {
            // Tell the BindingSource it should inform its clients (the DataGridView)
            // to update itself
            personBindingSource.ResetBindings(false);
        }
    }
